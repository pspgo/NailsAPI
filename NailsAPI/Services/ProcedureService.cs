using AutoMapper;
using NailsAPI.Entities;
using NailsAPI.Exceptions;
using NailsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI.Services
{
    public interface IProcedureService
    {
        int Create(CreateProcedureDto dto);
        IEnumerable<ProcedureDto> GetAll();
        ProcedureDto GetById(int id);
        void Remove(int id);
    }
    public class ProcedureService : IProcedureService
    {
        private readonly NailsDbContext _context;
        private readonly IMapper _mapper;
        public ProcedureService(NailsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(CreateProcedureDto dto)
        {
            var procedure = _context.Procedures.FirstOrDefault(p => p.Name == dto.Name);
            if (!(procedure is null))
                throw new AlreadyExistsException("Procedure already exists");

            var procedureEntity = _mapper.Map<Procedure>(dto);

            _context.Procedures.Add(procedureEntity);
            _context.SaveChanges();

            return procedureEntity.Id;
        }

        public IEnumerable<ProcedureDto> GetAll()
        {
            var procedures = _context
                .Procedures
                .ToList();

            var proceduresDtos = _mapper.Map<List<ProcedureDto>>(procedures);

            return proceduresDtos;
        }

        public ProcedureDto GetById(int id)
        {
            var procedure = GetProcedureById(id);
            var procedureDto = _mapper.Map<ProcedureDto>(procedure);
            return procedureDto;
        }

        public void Remove(int id)
        {
            var procedure = GetProcedureById(id);
            _context.RemoveRange(procedure);
            _context.SaveChanges();
        }

        public Procedure GetProcedureById(int id)
        {
            var procedure = _context
                .Procedures
                .FirstOrDefault(p => p.Id == id);

            if (procedure is null)
                throw new NotFoundException("Procedure not found");

            return procedure;
        }
    }
}
