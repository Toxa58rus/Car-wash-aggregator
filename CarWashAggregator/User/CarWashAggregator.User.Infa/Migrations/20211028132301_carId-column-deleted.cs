using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWashAggregator.User.Infa.Migrations
{
    public partial class carIdcolumndeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "NumberPhone",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "UserInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NumberPhone",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "UserInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
