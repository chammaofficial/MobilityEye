using Microsoft.EntityFrameworkCore;
using MobilityEye.Models;

namespace MobilityEye
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormControl> FormControls { get; set; }
        public DbSet<FormControlOption> FormControlOptions { get; set; }

        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
