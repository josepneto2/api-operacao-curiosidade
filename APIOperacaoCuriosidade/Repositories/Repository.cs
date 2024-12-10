using System.Linq.Expressions;
using APIOperacaoCuriosidade.Context;

namespace APIOperacaoCuriosidade.Repositories {
    public class Repository<T> : IRepository<T> where T : class {
        private readonly ApiDbContext _context;

        public Repository(ApiDbContext context) {
            _context = context;
        }

        public IEnumerable<T> BuscarTodos() {
            return _context.Set<T>().ToList();
        }
        
        public T? BuscarPorId(Expression<Func<T, bool>> predicate) {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T Criar(T entidade) {
            _context.Set<T>().Add(entidade);
            _context.SaveChanges();
            return entidade;
        }

        public T Atualizar(T entidade) {
            _context.Set<T>().Update(entidade);
            _context.SaveChanges();
            return entidade;
        }
        public T Deletar(T entidade) {
            _context.Set<T>().Remove(entidade);
            _context.SaveChanges();
            return entidade;
        }
    }
}
