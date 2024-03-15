using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLife.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsThemes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ThemeId",
                table: "News",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "NewsThemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsThemes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_ThemeId",
                table: "News",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsThemes_ThemeId",
                table: "News",
                column: "ThemeId",
                principalTable: "NewsThemes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsThemes_ThemeId",
                table: "News");

            migrationBuilder.DropTable(
                name: "NewsThemes");

            migrationBuilder.DropIndex(
                name: "IX_News_ThemeId",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "ThemeId",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
