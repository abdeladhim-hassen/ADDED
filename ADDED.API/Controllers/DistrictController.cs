using System.Collections.Generic;
using System.Threading.Tasks;
using ADDED.API.Data;
using ADDED.API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADDED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IADDEDRepository _repo;
        private readonly IMapper _mapper;
        public DistrictController(IADDEDRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<ActionResult> GetDistrict()
        {
            var districts = await _repo.GetDistrict();
            var DistrictstoReturn = _mapper.Map<IEnumerable<DistrictDto>>(districts);
            return Ok(DistrictstoReturn);
        }
    }
}