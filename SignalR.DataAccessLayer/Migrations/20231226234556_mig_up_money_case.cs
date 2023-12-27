using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class mig_up_money_case : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Moneycases",
                table: "Moneycases");

            migrationBuilder.RenameTable(
                name: "Moneycases",
                newName: "MoneyCases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoneyCases",
                table: "MoneyCases",
                column: "MoneyCaseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoneyCases",
                table: "MoneyCases");

            migrationBuilder.RenameTable(
                name: "MoneyCases",
                newName: "Moneycases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moneycases",
                table: "Moneycases",
                column: "MoneyCaseID");
        }
    }
}
