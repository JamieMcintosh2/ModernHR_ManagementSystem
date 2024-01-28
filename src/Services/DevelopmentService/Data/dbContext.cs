using DevelopmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentService.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> opt) :base(opt)
        {
        
        }

        public DbSet<EmpPerformance> performances { get; set; }
        public DbSet<EmpFeedback> feedbacks { get; set; }

        // DbSet for history entities
        public DbSet<PerformanceHistory> historicalPerformance { get; set; }
        public DbSet<FeedbackHistory> historicalFeedback { get; set; }

    }
}
