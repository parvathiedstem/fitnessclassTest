using Microsoft.EntityFrameworkCore;
using fitnessclass.Models;

namespace fitnessclass.Data
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options) { }

        public DbSet<FitnessClass> FitnessClasses { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
