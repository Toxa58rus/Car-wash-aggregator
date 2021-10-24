using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWashAggregator.Authorization.Infra.Migrations
{
    public partial class LoginasUniqueindexadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationData_user_login",
                table: "AuthorizationData",
                column: "user_login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthorizationData_user_login",
                table: "AuthorizationData");
        }
    }
}
