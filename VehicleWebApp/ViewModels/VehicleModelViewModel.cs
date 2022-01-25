using VehicleWebAppService.Models;
using X.PagedList;

namespace VehicleWebApp.ViewModels
{
    public class VehicleModelViewModel
    {
        public VehicleModel VehicleModel { get; set; }
        public VehicleMake VehicleMake { get; set; }

        public IPagedList<VehicleModel> VehicleModels { get; set; }
    }
}
