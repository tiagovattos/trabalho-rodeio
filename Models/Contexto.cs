using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using trabalho_rodeio.Areas.Identity.Data;

namespace trabalho_rodeio.Models
{
    public class Contexto : IdentityDbContext<UserRodeio>
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Peao> Peoes { get; set; }

        public DbSet<Touro> Touros { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Montaria> Montarias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
        }
    }
}

public class ApplicationUserConfiguration : IEntityTypeConfiguration<UserRodeio>
{
    public void Configure(EntityTypeBuilder<UserRodeio> builder)
    {
        builder.Property(x => x.Nome).HasMaxLength(100);
        builder.Property(x => x.Sobrenome).HasMaxLength(100);
    }
}