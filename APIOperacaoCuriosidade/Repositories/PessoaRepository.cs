using APIOperacaoCuriosidade.Context;
using APIOperacaoCuriosidade.Models;
using Microsoft.EntityFrameworkCore;

namespace APIOperacaoCuriosidade.Repositories {
    public class PessoaRepository : IRepository<Pessoa> {
        private readonly ApiDbContext _context;

        public PessoaRepository(ApiDbContext context) {
            _context = context;
        }

        public IEnumerable<Pessoa> BuscarTodos() {
            return _context.Pessoas.ToList();
        }

        public Pessoa BuscarPorId(int id) {
            return _context.Pessoas.FirstOrDefault(p => p.Id == id);
        }

        public Pessoa Criar(Pessoa pessoa) {
            if (pessoa == null) {
                throw new ArgumentNullException(nameof(pessoa));
            }

            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return pessoa;
        }

        public Pessoa Atualizar(Pessoa pessoa) {
            if (pessoa == null) {
                throw new ArgumentNullException(nameof(pessoa));
            }

            _context.Pessoas.Entry(pessoa).State = EntityState.Modified;
            _context.SaveChanges();
            return pessoa;
        }

        public Pessoa Deletar(int id) {
            var pessoa = _context.Pessoas.Find(id);
            if (pessoa == null) {
                throw new ArgumentNullException(nameof(pessoa));
            }

            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return pessoa;
        }
    }
}
