using GameHall.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameHall.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
            modelBuilder.Entity<Categoria>().ToTable("tb_categoria");

            _ = modelBuilder.Entity<Produto>()
                .HasOne(_ => _.Categoria)
                .WithMany(c => c.Produto)
                .HasForeignKey("CategoriaId")
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;

        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter()
                : base(dateOnly =>
                        dateOnly.ToDateTime(TimeOnly.MinValue),
                    dateTime => DateOnly.FromDateTime(dateTime))
            { }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insertedEntries = this.ChangeTracker.Entries()
                                    .Where(x => x.State == EntityState.Added)
                                    .Select(x => x.Entity);

          return base.SaveChangesAsync(cancellationToken);

        }

    }
}
