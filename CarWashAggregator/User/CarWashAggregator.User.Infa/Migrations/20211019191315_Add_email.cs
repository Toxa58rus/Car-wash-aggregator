using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWashAggregator.User.Infa.Migrations
{
    public partial class Add_email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserInfos",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserInfos");
        }
    }
}
