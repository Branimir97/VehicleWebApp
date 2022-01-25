using PagedList;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Interfaces;
using VehicleWebAppService.Models;

namespace VehicleWebAppService.Helpers
{
    class Paging
    {
        private readonly ISorting Sorting;
        private readonly IFiltering Filtering;

        public Paging(VehicleDbContext dbContext)
        {
            Sorting = new Sorting(dbContext);  
            Filtering = new Filtering(dbContext);
        }

        public async Task<PagedList<VehicleMake>> GetVehicleMakesBy(string sortOrder, string filter, int? pageNumber)
        {
            var sortedVehicleMakes = Sorting.SortVehicleMakes(sortOrder);
            var filteredVehicleMakes = Filtering.FilterVehicleMakes(filter);

            return await sortedVehicleMakes.ToPagedList(pageNumber ?? 1, 10);
           
        }
    }
}
