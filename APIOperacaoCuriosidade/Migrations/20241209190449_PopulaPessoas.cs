using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIOperacaoCuriosidade.Migrations
{
    /// <inheritdoc />
    public partial class PopulaPessoas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb) {
            mb.Sql("insert into Pessoas(" +
                    "Nome, " +
                    "Idade, " +
                    "Email, " +
                    "Endereco, " +
                    "OutrasInformacoes, " +
                    "Interesses, " +
                    "Sentimentos, " +
                    "Valores, " +
                    "DataCadastro, " +
                    "Status, " +
                    "Deletado) " +
                "Values(" +
                    "'Son Goku', " +
                    "35, " +
                    "'goku@email.com', " +
                    "'Distrito Leste 439', " +
                    "'Seu poder é mais de 8 mil', " +
                    "'Artes Marciais', " +
                    "'sentimentos', " +
                    "'valores', " +
                    "getdate(), " +
                    "'true', " +
                    "'false')");
            mb.Sql("insert into Pessoas(" +
                    "Nome, " +
                    "Idade, " +
                    "Email, " +
                    "Endereco, " +
                    "OutrasInformacoes, " +
                    "Interesses, " +
                    "Sentimentos, " +
                    "Valores, " +
                    "DataCadastro, " +
                    "Status, " +
                    "Deletado) " +
                "Values(" +
                    "'Virgil Super Choque', " +
                    "15, " +
                    "'superchoque@email.com', " +
                    "'Dakota', " +
                    "'outras infos', " +
                    "'interesses', " +
                    "'sentimentos', " +
                    "'valores', " +
                    "getdate(), " +
                    "'false', " +
                    "'false')");
            mb.Sql("insert into Pessoas(" +
                    "Nome, " +
                    "Idade, " +
                    "Email, " +
                    "Endereco, " +
                    "OutrasInformacoes, " +
                    "Interesses, " +
                    "Sentimentos, " +
                    "Valores, " +
                    "DataCadastro, " +
                    "Status, " +
                    "Deletado) " +
                "Values(" +
                    "'Logan Wolverine', " +
                    "100, " +
                    "'wolverine@email.com', " +
                    "'Alberta, Canadá', " +
                    "'Inimigo do Dentes de Sabre', " +
                    "'', " +
                    "'', " +
                    "'', " +
                    "getdate(), " +
                    "'true', " +
                    "'false')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb) {
            mb.Sql("delete from Pessoas");
        }
    }
}
