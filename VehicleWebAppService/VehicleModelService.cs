using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VehicleWebAppService
{
    public class VehicleModelService
    {
        private readonly VehicleDbContext DbContext;

        public VehicleModelService(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<PaginatedList<VehicleModel>> GetVehicleModels(
            string sortOrder, string searchString, int? pageNumber)
        {
            var vehicleModels = from v in DbContext.VehicleModels
                               select v;
            if (!string.IsNullOrEmpty(searchString))
            {
                vehicleModels = vehicleModels.Where(v => v.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "id_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.VehicleMakeId);
                    break;
                case "name_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.Name);
                    break;
                case "name_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.Name);
                    break;
                case "abrv_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.Abrv);
                    break;
                case "abrv_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.Abrv);
                    break;
                default:
                    vehicleModels = vehicleModels.OrderBy(v => v.VehicleMakeId);
                    break;
            }
            int pageSize = 10;
            return await PaginatedList<VehicleModel>.CreateAsync(vehicleModels.AsNoTracking(),
                        pageNumber ?? 1, pageSize);
        }
    }
}
