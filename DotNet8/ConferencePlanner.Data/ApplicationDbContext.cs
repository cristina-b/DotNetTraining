namespace ConferencePlanner.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<SessionSpeaker> SessionSpeaker { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>(a => a.HasIndex(e => e.UserName).IsUnique());

            SetPrimaryKeys(modelBuilder);
            SeedData(modelBuilder);
        }

        public static void SetPrimaryKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionAttendee>()
                .HasKey(ss => new { ss.SessionId, ss.AttendeeId });
            modelBuilder.Entity<SessionSpeaker>()
                .HasKey(ss => new { ss.SessionId, ss.SpeakerId });
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>().HasData(new List<Track>()
            {
                new Track {Id = 10, Name = "C#"},
                new Track {Id = 11, Name = "PHP"},
            });

            modelBuilder.Entity<Attendee>().Property(a => a.DateOfBirth).HasColumnName("DateOfBirth");
        }        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source = DESKTOP-VP4E8HD\SQLEXPRESS; database = ConferencePlanner; integrated security = SSPI");
            }
        }
    }
}