using NailsAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI
{
    public class NailsSeeder
    {
        private readonly NailsDbContext _dbContext;
        public NailsSeeder(NailsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if(!_dbContext.Appointments.Any())
                {
                    var appointments = GetAppointments();
                    _dbContext.Appointments.AddRange(appointments);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }

        private IEnumerable<Appointment> GetAppointments()
        {
            var appointment = new List<Appointment>()
            {
                new Appointment()
                {
                    MeetingDate = DateTime.Parse("16/01/2022"),
                    ProcedureId = 3
                }
            };
            return appointment;
        }

        //private IEnumerable<Procedure> GetAppointments()
        //{
        //    var appointments = new List<Appointment>()
        //    {
        //        new Appointment()
        //        {
        //            MeetingDate = DateTime.Parse("16/01/2022"),
        //            Procedures = new List<Procedure>()
        //            {
        //                new Procedure()
        //                {
        //                    ProcedureId = 3
        //                },
        //                new Procedure()
        //                {
        //                    ProcedureId = 4
        //                },
        //            }
        //        }
        //    };
        //    return (IEnumerable<Procedure>)appointments;
        //}

        //private IEnumerable<Procedure> GetProcedures()
        //{
        //    var procedures = new List<Procedure>()
        //    {
        //        new Procedure()
        //        {
        //            Name = "Manicure hybrydowy",
        //            Description = "Założenie nowej stylizacji hybrydowej",
        //            Price = "65",
        //            EstimatedTime = "1.5"
        //        },
        //        new Procedure()
        //        {
        //            Name = "Manicure żelowy na naturalnej płytce",
        //            Description = "Założenie nowej stylizacji żelowej na naturalnej płytce",
        //            Price = "85",
        //            EstimatedTime = "2"
        //        },
        //        new Procedure()
        //        {
        //            Name = "Przedłużanie paznokci na formie",
        //            Description = "Przedłużanie żelowe paznokci na formie",
        //            Price = "100",
        //            EstimatedTime = "2.5"
        //        },
        //        new Procedure()
        //        {
        //            Name = "Uzupełnienie stylizacji żelowej",
        //            Description = "Uzupełnienie stylizacji żelowej do 4 tygodni",
        //            Price = "75",
        //            EstimatedTime = "2"
        //        },
        //        new Procedure()
        //        {
        //            Name = "Ściąganie stylizacji żelowej/hybrydowej",
        //            Description = "",
        //            Price = "30",
        //            EstimatedTime = "20"
        //        }
        //    };

        //    return procedures;
        //}

    }
}
