using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomaPlayer.SoftArc.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexOfTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_IsnCenter",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_SurName_Name_LastName",
                table: "Trainers",
                columns: new[] { "SurName", "Name", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IsnCenter_SurName_Name_LastName",
                table: "Customers",
                columns: new[] { "IsnCenter", "SurName", "Name", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Centers_Name",
                table: "Centers",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trainers_SurName_Name_LastName",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IsnCenter_SurName_Name_LastName",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_Name",
                table: "Centers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IsnCenter",
                table: "Customers",
                column: "IsnCenter");
        }
    }
}
