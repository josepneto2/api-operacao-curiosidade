namespace APIOperacaoCuriosidade.Repositories; 
public interface IRepository<T> {
    IEnumerable<T> BuscarTodos();
    T BuscarPorId(int id);
    T Criar(T entidade);
    T Atualizar(T entidade);
    T Deletar(int id);

}
