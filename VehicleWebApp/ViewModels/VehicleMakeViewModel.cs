using VehicleWebAppService.Models;
using X.PagedList;

namespace VehicleWebApp.ViewModels
{
    public class VehicleMakeViewModel
    {
        public VehicleMake VehicleMake { get; set; }
        public IPagedList<VehicleMake> VehicleMakes { get; set; }
    }
}
