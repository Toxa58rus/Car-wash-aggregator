using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWashAggregator.CarWashes.Infra.Migrations
{
    public partial class Add_CityId_and_Phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "CarWashes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "CarWashes",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "CarWashes");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "CarWashes");
        }
    }
}
