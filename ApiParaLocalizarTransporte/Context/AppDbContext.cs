using ApiParaLocalizarTransporte.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiParaLocalizarTransporte.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Linha>? Linhas { get; set; }
        public DbSet<Parada>? Paradas { get; set; }
        public DbSet<PosicaoVeiculo>? PosicaoVeiculos { get; set; }
        public DbSet<Veiculo>? Veiculos { get; set; }
    }
}
