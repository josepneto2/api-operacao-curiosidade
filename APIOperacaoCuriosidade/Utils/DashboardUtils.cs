using APIOperacaoCuriosidade.Models;

namespace APIOperacaoCuriosidade.Utils; 
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

    public static int QuantidadeCadastrosPendentes(IEnumerable<Pessoa> cadastros) {
        int cadastrosPendentes = 0;
        
        foreach (var cadastro in cadastros) {
            var propriedades = cadastro.GetType().GetProperties();
            foreach (var propriedade in propriedades) {
                var valor = propriedade.GetValue(cadastro);
                if (valor == "") {
                    cadastrosPendentes++;
                    break;
                }
            }
        }
        
        return cadastrosPendentes;
    }
}