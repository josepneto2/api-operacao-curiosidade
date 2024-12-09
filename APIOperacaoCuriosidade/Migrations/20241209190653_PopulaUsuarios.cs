using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIOperacaoCuriosidade.Migrations
{
    /// <inheritdoc />
    public partial class PopulaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb) {
            mb.Sql("insert into Usuarios(" +
                    "Nome, " +
                    "Email, " +
                    "Senha, " +
                    "Deletado) " +
                "Values(" +
                    "'Admin', " +
                    "'admin@email.com', " +
                    "'admin', " +
                    "'false')");
            mb.Sql("insert into Usuarios(" +
                    "Nome, " +
                    "Email, " +
                    "Senha, " +
                    "Deletado) " +
                "Values(" +
                    "'Neto', " +
                    "'neto@email.com', " +
                    "'123', " +
                    "'false')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb) {
            mb.Sql("delete from Usuarios");
        }
    }
}
