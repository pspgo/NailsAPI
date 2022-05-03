using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI.Models
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime MeetingDate { get; set; }
        public int ProcedureId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string EstimatedTime { get; set; }
    }
}
