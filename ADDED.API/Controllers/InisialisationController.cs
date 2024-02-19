using System.Security.Claims;
using System.Threading.Tasks;
using ADDED.API.Data;
using ADDED.API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADDED.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InisialisationController : ControllerBase
    {
        private readonly IADDEDRepository _repo;
        private readonly IMapper _mapper;
        public InisialisationController(IADDEDRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpPost("verifier")]
        public async Task<ActionResult> GetInit(InitDtos initial)
        {   initial.CodDist = int.Parse(User.FindFirst(ClaimTypes.Locality).Value);
            initial.IdChef = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (await _repo.choixExist(initial))
            {
                return BadRequest("choix Plans deja Exist");
            } else
            {
                 if ( await _repo.GetInit(initial) )
                {
                    return Ok("Releve verifier");
                }
            }
             
            return BadRequest("Choix Plans Non Valide");
            }
            
        [HttpGet("information")]
        public async Task<ActionResult> GetInfo()
        {     int CodDist = int.Parse(User.FindFirst(ClaimTypes.Locality).Value);
              string Chef = User.FindFirst(ClaimTypes.Name).Value; 
              var info = new InfoInit();
              info.Chef = Chef;
              info.Dist = await _repo.GetDist(CodDist);
              return Ok (info);
        }
        [HttpPost("importer")]
        public async Task<ActionResult> PostInit(InitDtos initial)
        {   initial.CodDist = int.Parse(User.FindFirst(ClaimTypes.Locality).Value);
            initial.IdChef = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (await _repo.choixExist(initial))
            {
              var Tournee =  await _repo.ImportTournees(initial) ;
              if (Tournee)
              {
                  var detaille =  await _repo.ImportDetaille(initial) ;
                  return Ok("database imported");
              }
            }
            return BadRequest("il faut avant vérifier la choix Plans");
        }

        
    }
}