using EmploymentService.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EmploymentService.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> opt) : base(opt)
        {
            
        }
        public DbSet<Job> jobs { get; set; }
        public DbSet<Office> offices { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
