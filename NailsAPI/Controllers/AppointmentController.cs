using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NailsAPI.Entities;
using NailsAPI.Models;
using NailsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NailsAPI.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPut("{id}")]
        public ActionResult ChangeAppointment([FromRoute] int id, [FromBody] ChangeAppointment dto)
        {
            _appointmentService.Change(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _appointmentService.Delete(id);

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult CreateAppointment([FromBody] CreateAppointmentDto dto)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var id = _appointmentService.Create(dto);

            return Created($"/api/appointment/{id}", null);
        }

        [HttpGet]
        //[Authorize(Policy = "HasNationality")]    <- test customowa polityka claimem
        //[Authorize(Policy = "Atleast20")] <- test customowa polityka autoryzacji      
        //[Authorize(Policy = "AtLeast2Appointments")]
        public ActionResult<IEnumerable<AppointmentDto>> GetAll([FromQuery]AppointmentQuery query)
        {
            var appointmentsDtos = _appointmentService.GetAll(query);

            return Ok(appointmentsDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous] //pozwala bez autoryzacji
        public ActionResult<AppointmentDto> Get([FromRoute] int id)
        {
            var appointment =  _appointmentService.GetById(id);

            return Ok(appointment);
        }
    }
}
