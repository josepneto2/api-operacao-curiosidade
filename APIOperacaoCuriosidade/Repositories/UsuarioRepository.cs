using APIOperacaoCuriosidade.Context;
using APIOperacaoCuriosidade.Models;
using Microsoft.EntityFrameworkCore;

namespace APIOperacaoCuriosidade.Repositories;
public class UsuarioRepository : IRepository<Usuario> {
    private readonly ApiDbContext _context;

    public UsuarioRepository(ApiDbContext context) {
        _context = context;
    }

    public IEnumerable<Usuario> BuscarTodos() {
        return _context.Usuarios.ToList();
    }

    public Usuario BuscarPorId(int id) {
        return _context.Usuarios.FirstOrDefault(u => u.Id == id);
    }

    public Usuario Criar(Usuario usuario) {
        if (usuario == null) {
            throw new ArgumentNullException(nameof(usuario));
        }

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }

    public Usuario Atualizar(Usuario usuario) {
        if (usuario == null) {
            throw new ArgumentNullException(nameof(usuario));
        }

        _context.Usuarios.Entry(usuario).State = EntityState.Modified;
        _context.SaveChanges();
        return usuario;
    }

    public Usuario Deletar(int id) {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null) {
            throw new ArgumentNullException(nameof(usuario));
        }

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
        return usuario;
    }
}
