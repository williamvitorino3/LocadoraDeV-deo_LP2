using Microsoft.EntityFrameworkCore;
namespace WebApi.Models
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
    : base(options) {}
    public DataContext()
    {}

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<FilmeLocacao> FilmeLocacoes { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }
    public DbSet<Devolucao> Devolucoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      
      optionsBuilder.UseSqlServer("Server=localhost;Database=LocadoraLPII;Trusted_Connection=True;");
    }
  }
}