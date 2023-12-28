using EmploymentService.Models;
using System;
using System.Collections.Generic;
//This was used for testing before creating the concrete interface
/*
namespace EmploymentService.Data
{
    public class MockRepo : IEmploymentRepo
    {
        public IEnumerable<Job> GetAllJobs()
        {
            var jobs = new List<Job>
            {
                new Job{ Id = 0, JobTitle = "Warehouse Operative", Department = "Warehouse", salary = 24000 },
                new Job{ Id = 1, JobTitle = "Accountant", Department = "Finance", salary = 54000 },
                new Job{ Id = 2, JobTitle = "Electrical Engineer", Department = "Engineering", salary = 65000 }
            };
            return jobs;
        }

        public IEnumerable<Office> GetAllOffices()
        {
            var offices = new List<Office>
            {
                new Office { Id = 0, BuildingNum = 10, Street = "The Avenue", City = "Pittsburgh", Postcode = "PB10 XXX", Country = "United States"},
                new Office { Id = 1, BuildingNum = 12, Street = "The Street", City = "Guadalajara", Postcode = "GG10 BBX", Country = "Mexico" },
                new Office { Id = 2, BuildingNum = 9, Street = "Main Street", City = "London", Postcode = "LD10 24BB", Country = "England"}
            };
            return offices;
        }

        public Job GetJobById(int id)
        {
            return new Job { Id = 0, JobTitle = "Warehouse Operative", Department = "Warehouse", salary = 24000 };
        }

        public Office GetOfficeById(int id)
        {
            return new Office { Id = 0, BuildingNum = 12, Street = "The Street", City = "Edinburgh", Postcode = "EH10 2BR", Country = "Scotland"};
        }

        public bool saveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}*/
