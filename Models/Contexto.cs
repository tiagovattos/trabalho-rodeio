using Microsoft.EntityFrameworkCore;

namespace trabalho_rodeio.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Peao> Peoes { get; set; }

        public DbSet<Touro> Touros { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Montaria> Montarias { get; set; }
    }
}
