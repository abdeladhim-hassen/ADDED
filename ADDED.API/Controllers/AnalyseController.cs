using System.Collections.Generic;
using System.Threading.Tasks;
using ADDED.API.Data;
using ADDED.API.Dtos;
using ADDED.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADDED.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyseController : ControllerBase
    {
        private readonly IADDEDRepository _repo;
        private readonly IMapper _mapper;
        public AnalyseController(IADDEDRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

         [HttpGet("Index")]
         public async Task<IActionResult> GetIndexs([FromQuery] IndexParam indexParam)
        { 
            var indexs = await _repo.GetIndexs(indexParam);
            var IndextoReturn = _mapper.Map<IEnumerable<IndexDto>>(indexs);
            Response.AddPagination(indexs.CurrentPage, indexs.PageSize,
             indexs.TotalCount, indexs.TotalPages);
            return Ok(IndextoReturn);
        }
         [HttpGet("Anomalie")]
         public async Task<IActionResult> GetAnomalies([FromQuery] AnomalieParam anomalieParam)
        { 
            var Anomalies = await _repo.GetAnomalies(anomalieParam);
            var AnomaliestoReturn = _mapper.Map<IEnumerable<AnomalieDto>>(Anomalies);
            Response.AddPagination(Anomalies.CurrentPage, Anomalies.PageSize,
             Anomalies.TotalCount, Anomalies.TotalPages);
            return Ok(AnomaliestoReturn);
        }
         [HttpGet("Compteur")]
          public async Task<IActionResult> GetCompteurs([FromQuery] CompteurParam compteurParam)
        { 
            var Compteurs = await _repo.GetCompteurs(compteurParam);
            var CompteurstoReturn = _mapper.Map<IEnumerable<CompteurDto>>(Compteurs);
            Response.AddPagination(Compteurs.CurrentPage, Compteurs.PageSize,
             Compteurs.TotalCount, Compteurs.TotalPages);
            return Ok(CompteurstoReturn);
        }
    }
}
