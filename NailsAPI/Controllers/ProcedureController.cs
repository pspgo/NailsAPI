using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NailsAPI.Entities;
using NailsAPI.Models;
using NailsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI.Controllers
{
    //aby ten controller byl rozpoznawany przez framework asp.net
    //musi on dziedziczyc po klasie ControllerBase
    //ktora tez miedzy innymi udostepnia nam dostep do kontekstu zapytania i odp
    [Route("api/procedure")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly NailsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IProcedureService _procedureService;

        public ProcedureController(NailsDbContext dbContext, IMapper mapper, IProcedureService procedureService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _procedureService = procedureService;
        }

        [HttpDelete("{procedureId}")]
        public ActionResult Delete([FromRoute]int procedureId)
        {
            _procedureService.Remove(procedureId);
            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Post([FromBody] CreateProcedureDto dto)
        {
            var newProcedureId = _procedureService.Create(dto);

            return Created($"api/procedure/{newProcedureId}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProcedureDto>> GetAll()
        {
            var proceduresDto = _procedureService.GetAll();

            return Ok(proceduresDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ProcedureDto> Get([FromRoute] int id)
        {
            ProcedureDto procedure = _procedureService.GetById(id);
            return Ok(procedure);
        }
    }
}
