using System;
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
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningController : ControllerBase
    {
        private readonly IADDEDRepository _repo;
        private readonly IMapper _mapper;
        public PlanningController(IADDEDRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> GetPlannings([FromQuery]PlanningParam planningparam)
        {   var CurrentChef = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var plannings = await _repo.GetPlannings(CurrentChef, planningparam);
            var PlanningstoReturn = _mapper.Map<IEnumerable<PlanningDto>>(plannings);
            Response.AddPagination(plannings.CurrentPage, plannings.PageSize,
             plannings.TotalCount, plannings.TotalPages);
            return Ok(PlanningstoReturn);
        }
        [HttpGet("Releveur")]
        public async Task<ActionResult> GetListReleveurs()
        {
            var Releveurs = await _repo.GetListReleveurs(1);
            var ReleveurstoReturn = _mapper.Map<IEnumerable<AffectationDto>>(Releveurs);
            return Ok(ReleveurstoReturn);
        }

        [HttpGet("Tournee")]
        public async Task<ActionResult> GetListTournee()
        {
            var Tournees = await _repo.GetListTournee();
            var TourneestoReturn = _mapper.Map<IEnumerable<TourneeDto>>(Tournees);
            return Ok(TourneestoReturn);
        }
        
        [HttpPut]
        public async Task<IActionResult> PutPlanning(planningforcreation planning)
        {
            foreach (TourneeDto element in planning.Tournee)
            {var tournee = _repo.GetTournee(element.IdTour);
            tournee.IdReleveur = planning.Releveur;
            tournee.DatAffect = DateTime.Now;
            _repo.Modify(tournee);

                if (! await _repo.SaveAll())
                {
                    return BadRequest("failed");
                }
                
            
            } 
         return NoContent();
    }
}
}