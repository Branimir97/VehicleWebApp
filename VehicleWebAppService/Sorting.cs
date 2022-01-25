using System.Collections.Generic;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using System.Linq;

namespace VehicleWebAppService
{
    class Sorting : ISorting
    {
        private readonly VehicleDbContext DbContext;
        public Sorting(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<VehicleMake> SortVehicleMakes(string sortOrder)
        {
            var vehicleMakes = from v in DbContext.VehicleMakes
                               select v;
            vehicleMakes = sortOrder switch
            {
                "id_desc" => vehicleMakes.OrderByDescending(v => v.VehicleMakeId),
                "name_desc" => vehicleMakes.OrderByDescending(v => v.Name),
                "name_asc" => vehicleMakes.OrderBy(v => v.Name),
                "abrv_desc" => vehicleMakes.OrderByDescending(v => v.Abrv),
                "abrv_asc" => vehicleMakes.OrderBy(v => v.Abrv),
                _ => vehicleMakes.OrderBy(v => v.VehicleMakeId),
            };
            return vehicleMakes;
        }
    }
}
