using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleWebAppService.Models
{
    public class VehicleMake
    {
        [Key]
        public int VehicleMakeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
