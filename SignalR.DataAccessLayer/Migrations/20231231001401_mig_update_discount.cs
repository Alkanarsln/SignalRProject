using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class mig_update_discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "Discounts",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Discounts",
                newName: "description");
        }
    }
}
