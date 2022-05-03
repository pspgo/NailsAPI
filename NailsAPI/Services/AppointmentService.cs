using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NailsAPI.Authorization;
using NailsAPI.Entities;
using NailsAPI.Exceptions;
using NailsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using NailsAPI.Controllers;
using System.Linq.Expressions;

namespace NailsAPI.Services
{
    public interface IAppointmentService
    {
        int Create(CreateAppointmentDto dto);
        PagedResult<AppointmentDto> GetAll(AppointmentQuery query);
        //IEnumerable<AppointmentDto> GetAll();
        AppointmentDto GetById(int id);
        void Delete(int id);
        void Change(int id, ChangeAppointment dto);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly NailsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public AppointmentService(NailsDbContext dbContext, IMapper mapper, ILogger<AppointmentService> logger,
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public void Change(int id, ChangeAppointment dto)
        {
            var appointment = _dbContext
                .Appointments
                .FirstOrDefault(a => a.Id == id);

            if (appointment is null)
                throw new NotFoundException("Appointment not found");

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, appointment, 
                new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if(!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            appointment.MeetingDate = DateTime.Parse(dto.MeetingDate);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _logger.LogError($"Appointment with id: {id} DELETE action invoked");

            var appointment = _dbContext
                .Appointments
                .FirstOrDefault(a => a.Id == id);

            if (appointment is null)
                throw new NotFoundException("Appointment not found");

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, appointment,
                new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();
        }

        public AppointmentDto GetById(int id)
        {
            var appointment = _dbContext
                .Appointments
                .Include(a => a.Procedure)
                .FirstOrDefault(a => a.Id == id);

            if (appointment is null)
                throw new NotFoundException("Appointment not found");

            var result = _mapper.Map<AppointmentDto>(appointment);
            return result;
        }

        public PagedResult<AppointmentDto> GetAll(AppointmentQuery query)
        {
            var baseQuery = _dbContext
                .Appointments
                .Include(a => a.Procedure)
                .Where(a => query.SearchPhrase == null || (a.FirstName.ToLower().Contains(query.SearchPhrase.ToLower())
                    || a.LastName.ToLower().Contains(query.SearchPhrase.ToLower())));

            if(!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Appointment, object>>>
                {
                    { nameof(Appointment.LastName), a => a.LastName},
                    { nameof(Appointment.MeetingDate), a => a.MeetingDate},
                    { nameof(Appointment.Procedure.Name), a => a.Procedure.Name}
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var appointments = baseQuery
                .Skip(query.PageSize * (query.PageNumber -1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var appointmentsDtos = _mapper.Map<List<AppointmentDto>>(appointments);

            var result = new PagedResult<AppointmentDto>(appointmentsDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public int Create(CreateAppointmentDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);
            appointment.CreatedById = _userContextService.GetUserId;
            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();

            return appointment.Id;
        }
    }
}
