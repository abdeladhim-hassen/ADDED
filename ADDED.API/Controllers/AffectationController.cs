using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ADDED.API.Data;
using ADDED.API.Dtos;
using ADDED.API.Helpers;
using ADDED.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADDED.API.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AffectationController: ControllerBase
    {
        private readonly IADDEDRepository _repo;
        private readonly IMapper _mapper;
        public AffectationController(IADDEDRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> GetAffectattions([FromQuery]AffectationParam affectationparam)
        {   var CodDist = int.Parse(User.FindFirst(ClaimTypes.Locality).Value);
            var affectations = await _repo.GetAffectations(CodDist, affectationparam);
            var AffectationstoReturn = _mapper.Map<IEnumerable<AffectationDto>>(affectations);
            Response.AddPagination(affectations.CurrentPage, affectations.PageSize, affectations.TotalCount, affectations.TotalPages);
            return Ok(AffectationstoReturn);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Releveur>> GetAffectation (int id)
        {
            var affectation = await _repo.GetAffectation(id);

            if (affectation == null)
            {
                return NotFound();
            }

            return affectation;
        }
        [HttpGet("Releveur")]
        public async Task<ActionResult> GetListReleveurs()
        {
            var Releveurs = await _repo.GetListReleveurs(2);
            var ReleveurstoReturn = _mapper.Map<IEnumerable<ReleveurForAffectation>>(Releveurs);
            return Ok(ReleveurstoReturn);
        }

        [HttpGet("Portable")]
        public async Task<ActionResult> GetListPortables()
        {
            var Portables = await _repo.GetListPortables();
            var PortablestoReturn = _mapper.Map<IEnumerable<PortableForAffectation>>(Portables);
            return Ok(PortablestoReturn);
        }
        public async Task<IActionResult> PutAffectation( AffectationForCreation affectation)
        {
            Portable portable = await _repo.GetPortable(affectation.Portable);

            portable.IdReleveur =  affectation.Releveur;
            _repo.Modify(portable);

            if (! await _repo.SaveAll())
                {
                    return BadRequest("failed");
                }
                
                return NoContent();
            
            } 
         
    }
        
       

    }

