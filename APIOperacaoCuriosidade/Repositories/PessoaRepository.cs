using APIOperacaoCuriosidade.Context;
using APIOperacaoCuriosidade.Models;

namespace APIOperacaoCuriosidade.Repositories; 
public class PessoaRepository : Repository<Pessoa>, IPessoaRepository {
    public PessoaRepository(ApiDbContext context) : base(context) {
        
    }
}
