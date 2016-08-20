using Microsoft.EntityFrameworkCore;
using Vidisc2.Models;

namespace Vidisc2.Data
{
    public class DgContext : DbContext
    {
        public DgContext(DbContextOptions<DgContext> options)
            : base(options)
        { }

        public DbSet<Round> Rounds { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Scorecard> Scorecards { get; set; }
    }
}
