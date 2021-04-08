using Microsoft.EntityFrameworkCore;
using WebAppFasitec.Entities;

namespace WebAppFasitec.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {}

        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
