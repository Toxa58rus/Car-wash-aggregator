using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWashAggregator.ApiGateway.Infra.Migrations
{
    public partial class DbSetApiGatewaycorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "GatewayLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GatewayLogs",
                table: "GatewayLogs",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GatewayLogs",
                table: "GatewayLogs");

            migrationBuilder.RenameTable(
                name: "GatewayLogs",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "id");
        }
    }
}
