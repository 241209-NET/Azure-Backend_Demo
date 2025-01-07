using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class OwnerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Owners");
        }
    }
}
