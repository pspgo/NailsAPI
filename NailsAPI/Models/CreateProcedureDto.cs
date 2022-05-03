﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI.Models
{
    public class CreateProcedureDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string EstimatedTime { get; set; }
    }
}
