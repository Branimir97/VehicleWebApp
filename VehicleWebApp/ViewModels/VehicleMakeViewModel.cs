using VehicleWebAppService;
using VehicleWebAppService.Models;

namespace VehicleWebApp.ViewModels
{
    public class VehicleMakeViewModel
    {
        public VehicleMake VehicleMake { get; set; }
        public PaginatedList<VehicleMake> VehicleMakes { get; set; }
    }
}
