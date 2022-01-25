using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Interfaces;
using VehicleWebAppService.Models;
using X.PagedList;

namespace VehicleWebAppService.Helpers
{
    class Paging : IPaging
    {
        private readonly ISorting Sorting;
        private readonly IFiltering Filtering;

        public Paging(VehicleDbContext dbContext)
        {
            Sorting = new Sorting(dbContext);  
            Filtering = new Filtering(dbContext);
        }

        public async Task<IPagedList<VehicleMake>> GetVehicleMakesBy(string sortOrder, string filter, int? pageNumber)
        {
            var sortedVehicleMakes = Sorting.SortVehicleMakes(sortOrder);
            var filteredVehicleMakes = Filtering.FilterVehicleMakes(filter);
            return await filteredVehicleMakes.ToPagedListAsync(pageNumber ?? 1, 10);
        }
    }
}
