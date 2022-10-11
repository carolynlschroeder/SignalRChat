using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SignalRChat.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.To)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.Property(e => e.From)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.Property(e => e.Body)
                    .HasMaxLength(500)
                    .IsUnicode(false);

            });

            base.OnModelCreating(modelBuilder);

        }
    }
}