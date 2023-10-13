using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trabalho_rodeio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadeMontarias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Touros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    QuantidadeMontarias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Touros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Montarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeaoId = table.Column<int>(type: "int", nullable: false),
                    TouroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Montarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Montarias_Peoes_PeaoId",
                        column: x => x.PeaoId,
                        principalTable: "Peoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Montarias_Touros_TouroId",
                        column: x => x.TouroId,
                        principalTable: "Touros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Montarias_PeaoId",
                table: "Montarias",
                column: "PeaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Montarias_TouroId",
                table: "Montarias",
                column: "TouroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Montarias");

            migrationBuilder.DropTable(
                name: "Peoes");

            migrationBuilder.DropTable(
                name: "Touros");
        }
    }
}
