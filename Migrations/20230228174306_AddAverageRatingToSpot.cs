using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurritoBoysApi.Migrations
{
    public partial class AddAverageRatingToSpot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "State",
                keyValue: null,
                column: "State",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Spots",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "City",
                keyValue: null,
                column: "City",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Spots",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AverageRating",
                table: "Spots",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Salsas_SpotId",
                table: "Salsas",
                column: "SpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SpotId",
                table: "Ratings",
                column: "SpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Spots_SpotId",
                table: "Ratings",
                column: "SpotId",
                principalTable: "Spots",
                principalColumn: "SpotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salsas_Spots_SpotId",
                table: "Salsas",
                column: "SpotId",
                principalTable: "Spots",
                principalColumn: "SpotId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Spots_SpotId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Salsas_Spots_SpotId",
                table: "Salsas");

            migrationBuilder.DropIndex(
                name: "IX_Salsas_SpotId",
                table: "Salsas");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_SpotId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Spots");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Spots",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Spots",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
