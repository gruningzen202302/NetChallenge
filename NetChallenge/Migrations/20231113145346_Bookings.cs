using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetChallenge.Migrations
{
    /// <inheritdoc />
    public partial class Bookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableResources_Offices_OfficeId_LocationId",
                table: "AvailableResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableResources",
                table: "AvailableResources");

            migrationBuilder.RenameTable(
                name: "AvailableResources",
                newName: "Facilities");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableResources_OfficeId_LocationId",
                table: "Facilities",
                newName: "IX_Facilities_OfficeId_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OfficeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    OfficeLocationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Offices_OfficeId_LocationId",
                        columns: x => new { x.OfficeId, x.LocationId },
                        principalTable: "Offices",
                        principalColumns: new[] { "Id", "LocationId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Offices_OfficeId_OfficeLocationId",
                        columns: x => new { x.OfficeId, x.OfficeLocationId },
                        principalTable: "Offices",
                        principalColumns: new[] { "Id", "LocationId" });
                    table.ForeignKey(
                        name: "FK_Bookings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OfficeId_LocationId",
                table: "Bookings",
                columns: new[] { "OfficeId", "LocationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OfficeId_OfficeLocationId",
                table: "Bookings",
                columns: new[] { "OfficeId", "OfficeLocationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Offices_OfficeId_LocationId",
                table: "Facilities",
                columns: new[] { "OfficeId", "LocationId" },
                principalTable: "Offices",
                principalColumns: new[] { "Id", "LocationId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Offices_OfficeId_LocationId",
                table: "Facilities");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities");

            migrationBuilder.RenameTable(
                name: "Facilities",
                newName: "AvailableResources");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_OfficeId_LocationId",
                table: "AvailableResources",
                newName: "IX_AvailableResources_OfficeId_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableResources",
                table: "AvailableResources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableResources_Offices_OfficeId_LocationId",
                table: "AvailableResources",
                columns: new[] { "OfficeId", "LocationId" },
                principalTable: "Offices",
                principalColumns: new[] { "Id", "LocationId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
