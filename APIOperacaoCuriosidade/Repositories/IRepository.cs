using System.Linq.Expressions;

namespace APIOperacaoCuriosidade.Repositories; 
public interface IRepository<T> {
    IEnumerable<T> BuscarTodos();
    T? BuscarPorId(Expression<Func<T, bool>> predicate);
    T Criar(T entidade);
    T Atualizar(T entidade);
    T Deletar(T entidade);
    public T? BuscarPorNomeEmail(Expression<Func<T, bool>> predicate);
}
