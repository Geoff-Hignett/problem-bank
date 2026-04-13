using Microsoft.EntityFrameworkCore;
using ProblemBank.Api.Models;

namespace ProblemBank.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProblemQuestion> ProblemQuestions => Set<ProblemQuestion>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}