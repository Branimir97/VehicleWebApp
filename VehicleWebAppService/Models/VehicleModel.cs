using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleWebAppService.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public VehicleMake MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
