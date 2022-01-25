using System.Collections.Generic;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using System.Linq;
using VehicleWebAppService.Interfaces;

namespace VehicleWebAppService
{
    class Filtering : IFiltering
    {
        private readonly VehicleDbContext DbContext;

        public Filtering(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<VehicleMake> FilterVehicleMakes(string filter)
        {
            var vehicleMakes = from v in DbContext.VehicleMakes
                               select v;
            if (!string.IsNullOrEmpty(filter))
            {
                vehicleMakes = vehicleMakes.Where(v => v.Name.Contains(filter));
            }
            return vehicleMakes;
        }
    }
}
