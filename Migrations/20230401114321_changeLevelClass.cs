using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_Zespolowy.Migrations
{
    /// <inheritdoc />
    public partial class changeLevelClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelClasses_Offers_OfferId",
                table: "LevelClasses");

            migrationBuilder.DropIndex(
                name: "IX_LevelClasses_OfferId",
                table: "LevelClasses");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "LevelClasses");

            migrationBuilder.CreateTable(
                name: "LevelClassOffer",
                columns: table => new
                {
                    LevelClassesLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    OffersOfferId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelClassOffer", x => new { x.LevelClassesLevelId, x.OffersOfferId });
                    table.ForeignKey(
                        name: "FK_LevelClassOffer_LevelClasses_LevelClassesLevelId",
                        column: x => x.LevelClassesLevelId,
                        principalTable: "LevelClasses",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelClassOffer_Offers_OffersOfferId",
                        column: x => x.OffersOfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LevelClassOffer_OffersOfferId",
                table: "LevelClassOffer",
                column: "OffersOfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelClassOffer");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "LevelClasses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LevelClasses_OfferId",
                table: "LevelClasses",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelClasses_Offers_OfferId",
                table: "LevelClasses",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "OfferId");
        }
    }
}
