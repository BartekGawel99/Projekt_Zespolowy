using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_Zespolowy.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToOpinions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RewiewerName",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewiewerName",
                table: "Opinions");
        }
    }
}
