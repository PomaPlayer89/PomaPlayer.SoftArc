using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomaPlayer.SoftArc.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class FixCenterFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdressStreet",
                table: "Centers",
                newName: "AddressStreet");

            migrationBuilder.RenameColumn(
                name: "AdressNumberHouse",
                table: "Centers",
                newName: "AddressNumberHouse");

            migrationBuilder.RenameColumn(
                name: "AdressCity",
                table: "Centers",
                newName: "AddressCity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressStreet",
                table: "Centers",
                newName: "AdressStreet");

            migrationBuilder.RenameColumn(
                name: "AddressNumberHouse",
                table: "Centers",
                newName: "AdressNumberHouse");

            migrationBuilder.RenameColumn(
                name: "AddressCity",
                table: "Centers",
                newName: "AdressCity");
        }
    }
}
