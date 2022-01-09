using System.ComponentModel.DataAnnotations;

namespace VehicleWebAppService.Models
{
    public class VehicleModel
    {
        [Key]
        public int VehicleModelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
        [Required]
        public int VehicleMakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
