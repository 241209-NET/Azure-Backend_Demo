using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "Pets",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Pets");
        }
    }
}
