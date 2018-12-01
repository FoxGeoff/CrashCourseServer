using Microsoft.EntityFrameworkCore;

namespace CrashCourseServer.Models
{
    public class EntryDbContext : DbContext
    {
        public EntryDbContext(DbContextOptions<EntryDbContext> options) : base(options)
        {

        }

        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
