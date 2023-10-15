using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trabalho_rodeio.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Montarias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Montarias_CidadeId",
                table: "Montarias",
                column: "CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Montarias_Cidades_CidadeId",
                table: "Montarias",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Montarias_Cidades_CidadeId",
                table: "Montarias");

            migrationBuilder.DropIndex(
                name: "IX_Montarias_CidadeId",
                table: "Montarias");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Montarias");
        }
    }
}
