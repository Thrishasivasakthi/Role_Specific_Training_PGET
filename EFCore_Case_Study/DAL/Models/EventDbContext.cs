using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataAccess
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }
     
        public DbSet<SessionInfo> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<UserInfo>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<EventDetails>()
                .Property(e => e.Status)
                .HasConversion<string>();

            modelBuilder.Entity<SessionInfo>();
                

        }
    }
}