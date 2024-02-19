
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ADDED.API.Data;
using ADDED.API.Dtos;
using ADDED.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ADDED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(ChefForRegisterDto chefForRegisterDto)
        {   
            // validate request
            var mailTel = new MailTel();
            mailTel.MailChef = chefForRegisterDto.MailChef.ToLower();
            mailTel.TelChef = chefForRegisterDto.TelChef;
            if (await _repo.ChefExists(mailTel))
                return BadRequest("email or phone already exists");
            var ChefToCreate = new Chef
            {
                NomChef = chefForRegisterDto.NomChef,
                CodDist = chefForRegisterDto.CodDist,
                PrenomChef = chefForRegisterDto.PrenomChef,
                TelChef = chefForRegisterDto.TelChef,
                MailChef = chefForRegisterDto.MailChef
            };
            var createdChef = await _repo.Register(ChefToCreate, chefForRegisterDto.Password);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(ChefForLoginDto chefForLoginDto)
        {
            var chefFromRepo = await _repo.Login(chefForLoginDto.MailTel.ToLower(), chefForLoginDto.Password);

            if (chefFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,chefFromRepo.IdChef.ToString()),
                new Claim(ClaimTypes.Locality,chefFromRepo.CodDist.ToString()),
                new Claim(ClaimTypes.Name,chefFromRepo.NomChef + " "+ chefFromRepo.PrenomChef),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var chef = _mapper.Map<ChefDto>(chefFromRepo);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
