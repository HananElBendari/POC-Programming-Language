using Microsoft.EntityFrameworkCore;
using POC.Programming.Domain.Entities;

namespace POC.Programming.Infrastructure.Persistence
{
    public class ProgrammingContext : DbContext
    {
        public ProgrammingContext()
        {
        }
        public ProgrammingContext(DbContextOptions<ProgrammingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProgrammingCategory> ProgrammingCategory { get; set; }
        public virtual DbSet<ProgrammingLanguage> ProgrammingLanguage { get; set; }
        public virtual DbSet<ProgrammingLanguageDetails> ProgrammingLanguageDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=Programming;trusted_connection=true;");
        }
    }
}
