using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLCLicenseManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addApplicationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BLCApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLCApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BLCApplicationInstanceOfLicense",
                columns: table => new
                {
                    BLCApplicationsId = table.Column<int>(type: "int", nullable: false),
                    InstanceOfLicensesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLCApplicationInstanceOfLicense", x => new { x.BLCApplicationsId, x.InstanceOfLicensesId });
                    table.ForeignKey(
                        name: "FK_BLCApplicationInstanceOfLicense_BLCApplications_BLCApplicationsId",
                        column: x => x.BLCApplicationsId,
                        principalTable: "BLCApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BLCApplicationInstanceOfLicense_InstanceOfLicenses_InstanceOfLicensesId",
                        column: x => x.InstanceOfLicensesId,
                        principalTable: "InstanceOfLicenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "LicenseTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 6, 15, 18, 55, 0, 130, DateTimeKind.Local).AddTicks(3923), new DateTime(2023, 6, 15, 18, 55, 0, 130, DateTimeKind.Local).AddTicks(3923) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 6, 15, 18, 55, 0, 130, DateTimeKind.Local).AddTicks(4175), new DateTime(2023, 6, 15, 18, 55, 0, 130, DateTimeKind.Local).AddTicks(4176) });

            migrationBuilder.CreateIndex(
                name: "IX_BLCApplicationInstanceOfLicense_InstanceOfLicensesId",
                table: "BLCApplicationInstanceOfLicense",
                column: "InstanceOfLicensesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BLCApplicationInstanceOfLicense");

            migrationBuilder.DropTable(
                name: "BLCApplications");

            migrationBuilder.UpdateData(
                table: "LicenseTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 6, 13, 19, 19, 17, 258, DateTimeKind.Local).AddTicks(579), new DateTime(2023, 6, 13, 19, 19, 17, 258, DateTimeKind.Local).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 6, 13, 19, 19, 17, 258, DateTimeKind.Local).AddTicks(770), new DateTime(2023, 6, 13, 19, 19, 17, 258, DateTimeKind.Local).AddTicks(771) });
        }
    }
}
