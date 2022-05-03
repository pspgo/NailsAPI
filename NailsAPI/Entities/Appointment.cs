using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime MeetingDate { get; set; }
        public int ProcedureId { get; set; }
        public virtual Procedure Procedure { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNr { get; set; }
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}
