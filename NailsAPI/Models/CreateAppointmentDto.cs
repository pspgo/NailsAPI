using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI.Models
{
    public class CreateAppointmentDto
    {
        [Required]
        public string MeetingDate { get; set; }

        [Required]
        public int ProcedureId { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
