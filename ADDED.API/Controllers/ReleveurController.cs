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
    public class ReleveurController: ControllerBase
    {
        private readonly IADDEDRepository _repo;
        private readonly IMapper _mapper;
        public ReleveurController(IADDEDRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> GetReleveurs([FromQuery]ReleveurParam releveurparam)
        {   var CodDist = int.Parse(User.FindFirst(ClaimTypes.Locality).Value);
            var releveurs = await _repo.GetReleveurs(CodDist,releveurparam);
            var ReleveurstoReturn = _mapper.Map<IEnumerable<ReleveurDto>>(releveurs);
            Response.AddPagination(releveurs.CurrentPage, releveurs.PageSize, releveurs.TotalCount, releveurs.TotalPages);
            return Ok(ReleveurstoReturn);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Releveur>> GetReleveur (int id)
        {
            var releveur = await _repo.GetReleveur(id);

            if (releveur == null)
            {
                return NotFound();
            }
            return releveur;
        }
        [HttpPost]
        public async Task<IActionResult> PostReleveur (Releveurtocreate releveurtocreate)
        {
            var ToCreate = _mapper.Map<Releveur>(releveurtocreate);
            if(await _repo.ReleveurExisit(releveurtocreate.TSPUsername)) {
                return BadRequest("Username Already Exist");
            }
            var result = await _repo.AddReleveur(ToCreate);
             var ReleveurtoReturn = _mapper.Map<ReleveurDto>(result);
            return CreatedAtAction("GetReleveur", new { id = ToCreate.IdReleveur  }, ReleveurtoReturn);
        }
        [HttpDelete("{id}")]
       public async Task<ActionResult<Releveur>> DeleteReleveur(int id)
        {    var releveur = await _repo.GetReleveur(id);
            if ( releveur== null)
            {
                return NotFound();
            }

            _repo.Delete(releveur);
            await _repo.SaveAll();

            return releveur;
        }
        [HttpPut]
        public async Task<IActionResult> PutReleveur(Releveur releveur)
        {

            _repo.Modify(releveur);

            if (! await _repo.SaveAll())
                {
                    return BadRequest("failed to save");
                }

            return NoContent();
        }
       

    }
}