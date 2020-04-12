using Microsoft.EntityFrameworkCore;

namespace Evolution.Models
{
    public class EvolutionContext : DbContext
    {
        public EvolutionContext(DbContextOptions<EvolutionContext> options) 
            : base(options)
        {
        }

        public DbSet<ClassificationOfLife> ClassificationsOfLife { get; set; }
        public DbSet<Classification> Classifications { get; set; }

        public DbSet<GeologicalTimeScale> GeologicalTimeScales { get; set; }
        public DbSet<Timescale> Timescales { get; set; }

        public DbSet<Species> TheSpecies { get; set; }
        public DbSet<EvolutionaryPressure> EvolutionaryPressures { get; set; }
    }
}
