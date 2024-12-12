using APIOperacaoCuriosidade.Models;

namespace APIOperacaoCuriosidade.Utils {
    public static class DashboardUtils {
        public static int QuantidadeCadastrosUltimoMes(IEnumerable<Pessoa> cadastros) {
            int cadastrosUltimoMes = 0;
            int mesAtual = DateTime.Now.Month;

            foreach (var cadastro in cadastros) {
                int mesCadastro = cadastro.DataCadastro.Month;
                if (mesCadastro == mesAtual) {
                    cadastrosUltimoMes++;
                }
            }
            return cadastrosUltimoMes;
        }
    }
}
