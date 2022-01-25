using System.Collections.Generic;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using System.Linq;
using VehicleWebAppService.Interfaces;

namespace VehicleWebAppService
{
    class Sorting : ISorting
    {
        private readonly VehicleDbContext DbContext;
        public Sorting(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<VehicleMake> SortVehicleMakes(string sortOrder, IEnumerable<VehicleMake> VehicleMakes)
        {
            //var vehicleMakes = DbContext.VehicleMakes.AsQueryable();
            VehicleMakes = sortOrder switch
            {
                "id_desc" => VehicleMakes.OrderByDescending(v => v.VehicleMakeId),
                "name_desc" => VehicleMakes.OrderByDescending(v => v.Name),
                "name_asc" => VehicleMakes.OrderBy(v => v.Name),
                "abrv_desc" => VehicleMakes.OrderByDescending(v => v.Abrv),
                "abrv_asc" => VehicleMakes.OrderBy(v => v.Abrv),
                _ => VehicleMakes.OrderBy(v => v.VehicleMakeId),
            };
            return VehicleMakes;
        }
    }
}
