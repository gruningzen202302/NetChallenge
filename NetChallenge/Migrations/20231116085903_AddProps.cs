using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetChallenge.Migrations
{
    /// <inheritdoc />
    public partial class AddProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Offices_OfficeId_LocationId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Offices_OfficeId_OfficeLocationId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Offices_OfficeId_LocationId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Locations_LocationId",
                table: "Offices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offices",
                table: "Offices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Offices",
                newName: "Office");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "Facilities",
                newName: "Facility");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Offices_LocationId",
                table: "Office",
                newName: "IX_Office_LocationId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Facility",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_OfficeId_LocationId",
                table: "Facility",
                newName: "IX_Facility_OfficeId_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserId",
                table: "Booking",
                newName: "IX_Booking_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_OfficeId_OfficeLocationId",
                table: "Booking",
                newName: "IX_Booking_OfficeId_OfficeLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_OfficeId_LocationId",
                table: "Booking",
                newName: "IX_Booking_OfficeId_LocationId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Latitude",
                table: "Location",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Longitude",
                table: "Location",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Facility",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Facility",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office",
                table: "Office",
                columns: new[] { "Id", "LocationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facility",
                table: "Facility",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Office_OfficeId_LocationId",
                table: "Booking",
                columns: new[] { "OfficeId", "LocationId" },
                principalTable: "Office",
                principalColumns: new[] { "Id", "LocationId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Office_OfficeId_OfficeLocationId",
                table: "Booking",
                columns: new[] { "OfficeId", "OfficeLocationId" },
                principalTable: "Office",
                principalColumns: new[] { "Id", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_UserId",
                table: "Booking",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Office_OfficeId_LocationId",
                table: "Facility",
                columns: new[] { "OfficeId", "LocationId" },
                principalTable: "Office",
                principalColumns: new[] { "Id", "LocationId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Office_Location_LocationId",
                table: "Office",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Office_OfficeId_LocationId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Office_OfficeId_OfficeLocationId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_UserId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Office_OfficeId_LocationId",
                table: "Facility");

            migrationBuilder.DropForeignKey(
                name: "FK_Office_Location_LocationId",
                table: "Office");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office",
                table: "Office");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facility",
                table: "Facility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Facility");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Facility");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Office",
                newName: "Offices");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "Facility",
                newName: "Facilities");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Office_LocationId",
                table: "Offices",
                newName: "IX_Offices_LocationId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Facilities",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_OfficeId_LocationId",
                table: "Facilities",
                newName: "IX_Facilities_OfficeId_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserId",
                table: "Bookings",
                newName: "IX_Bookings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_OfficeId_OfficeLocationId",
                table: "Bookings",
                newName: "IX_Bookings_OfficeId_OfficeLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_OfficeId_LocationId",
                table: "Bookings",
                newName: "IX_Bookings_OfficeId_LocationId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offices",
                table: "Offices",
                columns: new[] { "Id", "LocationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Offices_OfficeId_LocationId",
                table: "Bookings",
                columns: new[] { "OfficeId", "LocationId" },
                principalTable: "Offices",
                principalColumns: new[] { "Id", "LocationId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Offices_OfficeId_OfficeLocationId",
                table: "Bookings",
                columns: new[] { "OfficeId", "OfficeLocationId" },
                principalTable: "Offices",
                principalColumns: new[] { "Id", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Offices_OfficeId_LocationId",
                table: "Facilities",
                columns: new[] { "OfficeId", "LocationId" },
                principalTable: "Offices",
                principalColumns: new[] { "Id", "LocationId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Locations_LocationId",
                table: "Offices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
