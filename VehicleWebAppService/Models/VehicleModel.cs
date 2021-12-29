﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleWebAppService.Models
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        public VehicleMake VehicleMake { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
    }
}
