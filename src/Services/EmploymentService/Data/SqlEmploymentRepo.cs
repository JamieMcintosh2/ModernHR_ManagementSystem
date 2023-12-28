using EmploymentService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmploymentService.Data
{
    public class SqlEmploymentRepo : IEmploymentRepo
    {
        private readonly dbContext _context;
        //Dependency injection to get DB context
        public SqlEmploymentRepo(dbContext context)
        {
            _context = context;
        }

        public void CreateEmployee(Employee employee)
        {
            //If null throw error
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            //Else emp passed in is not null, add it
            else
            {
                _context.employees.Add(employee);
            }
        }

        public void CreateJob(Job job)
        {
            //If null throw error
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            //Else emp passed in is not null, add it
            else
            {
                _context.jobs.Add(job);
            }
        }

        public void CreateOffice(Office off)
        {
            //If null throw error
            if (off == null)
            {
                throw new ArgumentNullException(nameof(off));
            }
            //Else emp passed in is not null, add it
            else
            {
                _context.offices.Add(off);
            }
        }

        public IEnumerable<Employee> GetAllEmployeesWithDetails()
        {
            return _context.employees
                .Include(e => e.Job)
                .Include(e => e.Office)
                .ToList();
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _context.jobs.ToList();
        }

        public IEnumerable<Office> GetAllOffices()
        {
            return _context.offices.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.employees
                .Include(e => e.Job)
                .Include(e => e.Office)
                .FirstOrDefault(e=> e.EmpId == id);
        }

        public Job GetJobById(int id)
        {
            return _context.jobs
                .FirstOrDefault(a => a.Id == id);
        }

        public Office GetOfficeById(int id)
        {
            return _context.offices
                .FirstOrDefault(a => a.Id == id);
        }

        public bool saveChanges()
        {
            //This method saves the changes in the database without this the changes wont be saved
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEmployee(Employee employee)
        {
            //Do nothing
        }

        public void UpdateJob(Job job)
        {
            //Do Nothing
        }

        public void UpdateOffice(Office off)
        {
            //Do Nothing
        }
    }
}
