using Microsoft.EntityFrameworkCore;

namespace ZadanieRekrutacyjne.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ZadanieRekrutacyjne> ZadanieRekrutacyjnes { get; set; }

        public DbSet<Kategoria> Kategorias { get; set; }
    }
}
