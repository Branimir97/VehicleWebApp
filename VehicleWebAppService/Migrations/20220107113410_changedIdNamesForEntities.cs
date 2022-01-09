using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleWebAppService.Migrations
{
    public partial class changedIdNamesForEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehicleModels",
                newName: "VehicleModelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehicleMakes",
                newName: "VehicleMakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleModelId",
                table: "VehicleModels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VehicleMakeId",
                table: "VehicleMakes",
                newName: "Id");
        }
    }
}
