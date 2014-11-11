using System.Data.Entity;

namespace CodeVerifier.Models
{
    public class MaidDbContext:DbContext
    {
        public DbSet<Problem> Problems { get; set; }
        public DbSet<ProblemSolution> ProblemSolutions { get; set; } 
    }
}