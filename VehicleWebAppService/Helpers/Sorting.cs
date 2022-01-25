using System.Collections.Generic;
using VehicleWebAppService.Models;
using System.Linq;
using VehicleWebAppService.Interfaces;

namespace VehicleWebAppService
{
    class Sorting : ISorting
    {
        public IEnumerable<VehicleMake> SortVehicleMakes(string sortOrder, IEnumerable<VehicleMake> VehicleMakes)
        {
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

        public IEnumerable<VehicleModel> SortVehicleModels(string sortOrder, IEnumerable<VehicleModel> VehicleModels)
        {
            VehicleModels = sortOrder switch
            {
                "id_desc" => VehicleModels.OrderByDescending(v => v.VehicleModelId),
                "veh_make_asc" => VehicleModels.OrderBy(v => v.VehicleMake.Name),
                "veh_make_desc" => VehicleModels.OrderByDescending(v => v.VehicleMake.Name),
                "veh_abrv_asc" => VehicleModels.OrderBy(v => v.VehicleMake.Abrv),
                "veh_abrv_desc" => VehicleModels.OrderByDescending(v => v.VehicleMake.Abrv),
                "model_asc" => VehicleModels.OrderBy(v => v.Name),
                "model_desc" => VehicleModels.OrderByDescending(v => v.Name),
                "abrv_asc" => VehicleModels.OrderBy(v => v.Abrv),
                "abrv_desc" => VehicleModels.OrderByDescending(v => v.Abrv),
                _ => VehicleModels.OrderBy(v => v.VehicleModelId),
            };
            return VehicleModels;
        }
    }
}
