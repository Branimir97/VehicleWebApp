using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleWebAppService.Migrations
{
    public partial class SeededMoreVehicleMakes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 1,
                column: "Name",
                value: "Bayerische Motoren Werke AG");

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 2,
                column: "Name",
                value: "Ford Motor Company");

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 3,
                column: "Name",
                value: "Audi AG");

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 4,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "Fiat", "Fiat S.p.A." });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 5,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "VW", "Volkswagen" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 6,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "Opel", "Opel Automobile GmbH" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 7,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "GM", "General Motors" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 8,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "Hyundai", "Hyundai Motor Company" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 9,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "Honda", "Honda Motor Company" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 10,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "Toyota", "Toyota Motor Corporation" });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "VehicleMakeId", "Abrv", "Name" },
                values: new object[,]
                {
                    { 11, "Mercedes", "Mercedes-Benz" },
                    { 12, "Peugeot", "Peugeot S.A." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 1,
                column: "Name",
                value: "BMW");

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 2,
                column: "Name",
                value: "Ford");

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 3,
                column: "Name",
                value: "Audi");

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 4,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "Porsche", "Porsche" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 5,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "Fiat", "Fiat" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 6,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "BMW", "BMW" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 7,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "VW", "Volkswagen" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 8,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "VW", "Volkswagen" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 9,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "Opel", "Opel" });

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 10,
                columns: new[] { "Abrv", "Name" },
                values: new object[] { "GM", "General Motors" });
        }
    }
}
