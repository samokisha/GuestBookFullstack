using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GuestBookFullstack.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuestBookFullstack.Data
{
    public class GuestBookContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public GuestBookContext(DbContextOptions<GuestBookContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Comment>()
                .Property(c => c.CommentType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            ChangeTracker.DetectChanges();
            
            ChangeTracker
                .Entries<Comment>()
                .Where(e => e.State == EntityState.Added)
                .ToList()
                .ForEach(e => e.Entity.CreatedAt = DateTime.UtcNow);
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}