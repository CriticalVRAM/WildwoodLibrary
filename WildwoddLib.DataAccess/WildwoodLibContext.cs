using Microsoft.EntityFrameworkCore;
using WildwoodLib.Domain.Entites;

namespace WildwoddLib.DataAccess
{
    public class WildwoodLibContext : DbContext
    {
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-829F9LU\SQLEXPRESS;Initial Catalog=WildwoodLib.v1;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                // set default delete behavior to restrict
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();

            modelBuilder.Entity<Book>().HasIndex(x => x.Title).IsUnique();

            modelBuilder.Entity<Checkout>().Property(x => x.DateStart).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<UserUseCase>().HasKey(c => new { c.UserId, c.UseCaseId });

            modelBuilder.Entity<Book>().Property(x => x.Quantity).HasDefaultValueSql("1");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
    }
}