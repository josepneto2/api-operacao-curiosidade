namespace APIOperacaoCuriosidade.Models {
    public class DashboardInfos {
        public int TotalCadastros { get; set; }
        public int CadastrosUltimoMes { get; set; }
        public int CadastrosPendentes { get; set; }

        public DashboardInfos(int totalCadastros, int cadastrosUltimoMes, int cadastrosPendentes) {
            TotalCadastros = totalCadastros;
            CadastrosUltimoMes = cadastrosUltimoMes;
            CadastrosPendentes = cadastrosPendentes;
        }
    }
}
