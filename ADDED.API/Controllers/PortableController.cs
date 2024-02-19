using System.Collections.Generic;
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
    public class PortableController : ControllerBase
    {
        private readonly IADDEDRepository _repo;
        private readonly IMapper _mapper;
        public PortableController(IADDEDRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> GetPortables([FromQuery]PortableParam portableparam)
        {
            var portables = await _repo.GetPortables(portableparam);
            var PortablestoReturn = _mapper.Map<IEnumerable<PortableDto>>(portables);
            Response.AddPagination(portables.CurrentPage, portables.PageSize, portables.TotalCount, portables.TotalPages);
            return Ok(PortablestoReturn);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Portable>> GetPortable (int id)
        {
            var portable = await _repo.GetPortable(id);

            if (portable == null)
            {
                return NotFound();
            }

            return portable;
        }
        [HttpPost]
        public async Task<IActionResult> PostPortable (Portabletocreate portabletocreate)
        {
            var ToCreate = _mapper.Map<Portable>(portabletocreate);
            var result = await _repo.AddPortable(ToCreate);
            return CreatedAtAction("GetPortable", new { id = ToCreate.IdPort  }, result);
        }
        [HttpDelete("{id}")]
       public async Task<ActionResult<Portable>> DeletePortable(int id)
        {    var portable = await _repo.GetPortable(id);
            if ( portable== null)
            {
                return NotFound();
            }

            _repo.Delete(portable);
            await _repo.SaveAll();

            return portable;
        }
        [HttpPut]
        public async Task<IActionResult> PutPortable(Portable portable)
        {

            _repo.Modify(portable);

            if (! await _repo.SaveAll())
                {
                    return BadRequest("failed");
                }

            return NoContent();
        }
       


    }
}