using AutoMapper;
using NailsAPI.Entities;
using NailsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI
{
    public class NailsMappingProfile: Profile
    {
        public NailsMappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(m => m.Name, c => c.MapFrom(s => s.Procedure.Name))
                .ForMember(m => m.Description, c => c.MapFrom(s => s.Procedure.Description))
                .ForMember(m => m.EstimatedTime, c => c.MapFrom(s => s.Procedure.EstimatedTime))
                .ForMember(m => m.Price, c => c.MapFrom(s => s.Procedure.Price));

            CreateMap<CreateAppointmentDto, Appointment>();

            CreateMap<Procedure, ProcedureDto>();

            CreateMap<CreateProcedureDto, Procedure>();
        }
    }
}
