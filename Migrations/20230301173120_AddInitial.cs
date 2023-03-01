using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurritoBoysApi.Migrations
{
    public partial class AddInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Spots",
                columns: table => new
                {
                    SpotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AverageRating = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spots", x => x.SpotId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    SpotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Spots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "Spots",
                        principalColumn: "SpotId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salsas",
                columns: table => new
                {
                    SalsaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salsas", x => x.SalsaId);
                    table.ForeignKey(
                        name: "FK_Salsas_Spots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "Spots",
                        principalColumn: "SpotId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Spots",
                columns: new[] { "SpotId", "Address", "AverageRating", "City", "Name", "State", "Website" },
                values: new object[,]
                {
                    { 1, "1122 S Maryland Pkwy suite 110", 4.6600000000000001, "Las Vegas", "Robertos", "NV", "www.Robertos.com" },
                    { 2, "707 NE Weidler St", 3.3300000000000001, "Portland", "Muchas Gracias", "OR", "www.MuchasGracias.com" },
                    { 3, "5745 NE Prescott St", 5.0, "Portland", "Pinches Burros", "OR", "www.PinchesBurros.com" },
                    { 4, "3503 N Mississippi Ave", 4.3300000000000001, "Portland", "King Burrito", "OR", "www.KingBurrito.com" },
                    { 5, "If you know, You know", 4.0, "Portland", "Los Francos", "OR", "food" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "Rate", "SpotId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 4, 1 },
                    { 3, 5, 1 },
                    { 4, 4, 2 },
                    { 5, 3, 2 },
                    { 6, 3, 2 },
                    { 7, 5, 3 },
                    { 8, 5, 3 },
                    { 9, 5, 3 },
                    { 10, 4, 4 },
                    { 11, 4, 4 },
                    { 12, 5, 4 },
                    { 13, 4, 5 },
                    { 14, 4, 5 },
                    { 15, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Salsas",
                columns: new[] { "SalsaId", "Description", "Name", "SpotId" },
                values: new object[,]
                {
                    { 1, "Mild but delicious.", "Green Salsa", 1 },
                    { 2, "Medium spicy and creamy..", "Avocado Salsa", 2 },
                    { 3, "Smokey and spicy.", "Chipotle Salsa", 3 },
                    { 4, "Spicy.", "Habenero Salsa", 4 },
                    { 5, "Firey.", "Red Salsa", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SpotId",
                table: "Ratings",
                column: "SpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Salsas_SpotId",
                table: "Salsas",
                column: "SpotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Salsas");

            migrationBuilder.DropTable(
                name: "Spots");
        }
    }
}
