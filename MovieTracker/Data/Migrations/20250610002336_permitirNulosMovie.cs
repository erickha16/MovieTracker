using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTracker.Migrations
{
    /// <inheritdoc />
    public partial class permitirNulosMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Platforms_PlataformId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Ratings_RatingId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_RatingId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "RatingId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlataformId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RatingId",
                table: "Movies",
                column: "RatingId",
                unique: true,
                filter: "[RatingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Platforms_PlataformId",
                table: "Movies",
                column: "PlataformId",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Ratings_RatingId",
                table: "Movies",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Platforms_PlataformId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Ratings_RatingId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_RatingId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "RatingId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlataformId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RatingId",
                table: "Movies",
                column: "RatingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Platforms_PlataformId",
                table: "Movies",
                column: "PlataformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Ratings_RatingId",
                table: "Movies",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
