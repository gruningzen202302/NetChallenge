using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetChallenge.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeOfficeLocationFacilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Offices",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Offices");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Offices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Offices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offices",
                table: "Offices",
                columns: new[] { "Id", "LocationId" });

            migrationBuilder.CreateTable(
                name: "AvailableResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    OfficeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableResources_Offices_OfficeId_LocationId",
                        columns: x => new { x.OfficeId, x.LocationId },
                        principalTable: "Offices",
                        principalColumns: new[] { "Id", "LocationId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offices_LocationId",
                table: "Offices",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableResources_OfficeId_LocationId",
                table: "AvailableResources",
                columns: new[] { "OfficeId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Locations_LocationId",
                table: "Offices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Locations_LocationId",
                table: "Offices");

            migrationBuilder.DropTable(
                name: "AvailableResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offices",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Offices_LocationId",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Offices");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Offices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Offices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offices",
                table: "Offices",
                column: "Id");
        }
    }
}
