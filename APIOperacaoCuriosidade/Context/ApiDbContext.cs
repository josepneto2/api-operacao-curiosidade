using APIOperacaoCuriosidade.Models;
using Microsoft.EntityFrameworkCore;

namespace APIOperacaoCuriosidade.Context; 
public class ApiDbContext : DbContext {
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base (options) {
    }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
