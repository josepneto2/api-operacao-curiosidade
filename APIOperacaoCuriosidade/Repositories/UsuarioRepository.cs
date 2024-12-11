using APIOperacaoCuriosidade.Context;
using APIOperacaoCuriosidade.Models;

namespace APIOperacaoCuriosidade.Repositories {
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository {
        public UsuarioRepository(ApiDbContext context) : base(context) {
        }
    }
}
