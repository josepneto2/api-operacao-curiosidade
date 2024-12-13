using System.Linq.Expressions;

namespace APIOperacaoCuriosidade.Repositories; 
public interface IRepository<T> {
    IEnumerable<T> BuscarTodos();
    T? BuscarPorId(Expression<Func<T, bool>> predicate);
    T? Criar(T entidade);
    T? Atualizar(T entidade);
    T? Deletar(T entidade);
    IEnumerable<T> FiltrarPorNomeEmail(Expression<Func<T, bool>> predicate);
    T? BuscarPorNomeEmail(Expression<Func<T, bool>> predicate);
    bool Existe(Expression<Func<T, bool>> predicate);
}
