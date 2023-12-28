using Microsoft.EntityFrameworkCore;
using ProfileService.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProfileService.Data
{
    //Inheriting DB Context from downloaded packages
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> opt) : base(opt)
        {

        }

        //Mapping Model class here, each model class would need another DbSet
        public DbSet<Employee> employees { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<EmergencyContact> emContacts { get; set; }
    }
}
