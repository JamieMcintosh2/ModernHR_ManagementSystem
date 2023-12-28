/*using ProfileService.Models;
using System;
using System.Collections.Generic;

namespace ProfileService.Data
{
    // Class used for testing
    public class MockRepo : IEmployeeRepo
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee{Id = 0, fName = "Jamie", lName = "McIntosh", DOB = new DateTimeOffset(new DateTime(1995, 07, 05)), pNumber = "07923292287" },
                new Employee{Id = 1, fName = "Bob", lName = "Senior", DOB = new DateTimeOffset(new DateTime(1955, 12, 05)), pNumber = "07923293387" },
                new Employee{Id = 2, fName = "Jimmy", lName = "Jones", DOB = new DateTimeOffset(new DateTime(1965, 01, 05)), pNumber = "07923293300" }
            };
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return new Employee { Id = 0, fName = "Jamie", lName = "McIntosh", DOB = new DateTimeOffset(new DateTime(1995, 07, 05)), pNumber = "07923292287" };
        }
    }
}
*/