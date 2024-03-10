using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLife.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarDeleteDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearOfManufecture",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YearOfManufecture",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
