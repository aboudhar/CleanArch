using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLCLicenseManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addApplicationTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BLCApplicationInstanceOfLicense");

            migrationBuilder.CreateTable(
                name: "BLCApplicationLicense",
                columns: table => new
                {
                    BLCApplicationsId = table.Column<int>(type: "int", nullable: false),
                    LicensesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLCApplicationLicense", x => new { x.BLCApplicationsId, x.LicensesId });
                    table.ForeignKey(
                        name: "FK_BLCApplicationLicense_BLCApplications_BLCApplicationsId",
                        column: x => x.BLCApplicationsId,
                        principalTable: "BLCApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BLCApplicationLicense_Licenses_LicensesId",
                        column: x => x.LicensesId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "LicenseTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 6, 15, 18, 59, 54, 507, DateTimeKind.Local).AddTicks(7820), new DateTime(2023, 6, 15, 18, 59, 54, 507, DateTimeKind.Local).AddTicks(7821) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 6, 15, 18, 59, 54, 507, DateTimeKind.Local).AddTicks(8021), new DateTime(2023, 6, 15, 18, 59, 54, 507, DateTimeKind.Local).AddTicks(8022) });

            migrationBuilder.CreateIndex(
                name: "IX_BLCApplicationLicense_LicensesId",
                table: "BLCApplicationLicense",
                column: "LicensesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BLCApplicationLicense");

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
    }
}
