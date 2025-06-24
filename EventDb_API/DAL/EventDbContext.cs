using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }
        public DbSet<SpeakerDetails> Speakers { get; set; }
        public DbSet<SessionInfo> Sessions { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventDetails>()
                .HasCheckConstraint("CK_Status", "[Status] IN ('Active', 'In-Active')");

            modelBuilder.Entity<ParticipantEventDetails>()
                .Property(e => e.IsAttended)
                .HasConversion<string>();
        }
    }

}
