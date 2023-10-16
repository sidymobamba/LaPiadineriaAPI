using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Piadineria2.Migrations
{
    public partial class p1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bibite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sku = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibite", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Piadine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Forma = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piadine", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sku = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PiadinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Piadine_PiadinaId",
                        column: x => x.PiadinaId,
                        principalTable: "Piadine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Bibite",
                columns: new[] { "Id", "Nome", "Prezzo", "Sku" },
                values: new object[,]
                {
                    { 1, "Coca Cola", 2.00m, "971b" },
                    { 2, "Fanta", 2.00m, "4236" },
                    { 3, "Pepsi", 2.50m, "192f" }
                });

            migrationBuilder.InsertData(
                table: "Piadine",
                columns: new[] { "Id", "Forma", "Nome", "Prezzo" },
                values: new object[,]
                {
                    { 1, "Aperta", "Piadina Prosciutto e Formaggio", 5.50m },
                    { 2, "Rotolo", "Piadina Tacchino e Maionese", 6.00m },
                    { 3, "Aperta", "Piadina MegaTwist", 7.00m }
                });

            migrationBuilder.InsertData(
                table: "Snacks",
                columns: new[] { "Id", "Nome", "Prezzo", "Sku" },
                values: new object[,]
                {
                    { 1, "Patatine", 2.50m, "087e" },
                    { 2, "Popcorn", 5.00m, "a46a" },
                    { 3, "Salsa", 2.00m, "ec7e" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "PiadinaId" },
                values: new object[,]
                {
                    { 1, "Prosciutto", 1 },
                    { 2, "Formaggio", 1 },
                    { 3, "Tacchino", 2 },
                    { 4, "Maionese", 2 },
                    { 5, "Tacchino", 3 },
                    { 6, "Maionese", 3 },
                    { 7, "Formaggio", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_PiadinaId",
                table: "Ingredients",
                column: "PiadinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bibite");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Snacks");

            migrationBuilder.DropTable(
                name: "Piadine");
        }
    }
}
