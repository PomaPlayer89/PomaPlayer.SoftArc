using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomaPlayer.SoftArc.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class Init_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdressStreet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdressNumberHouse = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.IsnNode);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.IsnNode);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnCenter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IsnNode);
                    table.ForeignKey(
                        name: "FK_Customers_Centers_IsnCenter",
                        column: x => x.IsnCenter,
                        principalTable: "Centers",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentersTrainers",
                columns: table => new
                {
                    IsnCenter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnTrainer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentersTrainers", x => new { x.IsnCenter, x.IsnTrainer });
                    table.ForeignKey(
                        name: "FK_CentersTrainers_Centers_IsnCenter",
                        column: x => x.IsnCenter,
                        principalTable: "Centers",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CentersTrainers_Trainers_IsnTrainer",
                        column: x => x.IsnTrainer,
                        principalTable: "Trainers",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainersCustomers",
                columns: table => new
                {
                    IsnTrainer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainersCustomers", x => new { x.IsnTrainer, x.IsnCustomer });
                    table.ForeignKey(
                        name: "FK_TrainersCustomers_Customers_IsnCustomer",
                        column: x => x.IsnCustomer,
                        principalTable: "Customers",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainersCustomers_Trainers_IsnTrainer",
                        column: x => x.IsnTrainer,
                        principalTable: "Trainers",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentersTrainers_IsnCenter_IsnTrainer",
                table: "CentersTrainers",
                columns: new[] { "IsnCenter", "IsnTrainer" });

            migrationBuilder.CreateIndex(
                name: "IX_CentersTrainers_IsnTrainer",
                table: "CentersTrainers",
                column: "IsnTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IsnCenter",
                table: "Customers",
                column: "IsnCenter");

            migrationBuilder.CreateIndex(
                name: "IX_TrainersCustomers_IsnCustomer",
                table: "TrainersCustomers",
                column: "IsnCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_TrainersCustomers_IsnTrainer_IsnCustomer",
                table: "TrainersCustomers",
                columns: new[] { "IsnTrainer", "IsnCustomer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CentersTrainers");

            migrationBuilder.DropTable(
                name: "TrainersCustomers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Centers");
        }
    }
}
