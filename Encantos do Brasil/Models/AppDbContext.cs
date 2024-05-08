using Microsoft.EntityFrameworkCore;

namespace Encantos_do_Brasil.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RegiaoPais> RegioesPais { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Hotel> Hoteis { get; set; }

        public DbSet<TelefoneHotel> Telefones { get; set; }

        public DbSet<PontoTuristico> PontosTuristicos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Favorito> Favoritos { get; set; }
    }
}
