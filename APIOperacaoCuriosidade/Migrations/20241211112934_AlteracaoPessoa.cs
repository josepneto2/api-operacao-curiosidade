using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIOperacaoCuriosidade.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Pessoas",
                newName: "Ativo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Pessoas",
                newName: "Status");
        }
    }
}
