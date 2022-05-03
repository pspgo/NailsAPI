using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI.Models
{
    public class ChangeAppointment
    {
        [Required]
        public string MeetingDate { get; set; }
        public int ProcedureId { get; set; }
    }
}
