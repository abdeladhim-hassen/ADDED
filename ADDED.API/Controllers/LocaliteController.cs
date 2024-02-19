using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ADDED.API.Data;
using ADDED.API.Dtos;
using ADDED.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADDED.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocaliteController : ControllerBase
    {
        
        private readonly IADDEDRepository _repo;
        private readonly IMapper _mapper;
        public LocaliteController(IADDEDRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<ActionResult> GetLocalite()
        {   var currentChefIdDist = int.Parse(User.FindFirst(ClaimTypes.Locality).Value);
            var Localites = await _repo.GetLocalite(currentChefIdDist);
            var LocalitestoReturn = _mapper.Map<IEnumerable<LocaliteDto>>(Localites);
            return Ok(LocalitestoReturn);
        }
}
}

