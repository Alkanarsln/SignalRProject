using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class mig_update_menutable_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Satatus",
                table: "MenuTables",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "MenuTables",
                newName: "Satatus");
        }
    }
}
