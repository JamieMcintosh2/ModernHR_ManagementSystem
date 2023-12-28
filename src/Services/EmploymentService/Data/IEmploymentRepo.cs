using EmploymentService.Models;
using System.Collections.Generic;

namespace EmploymentService.Data
{
    public interface IEmploymentRepo
    {
        bool saveChanges();
        // Get all of the Jobs
        IEnumerable<Job> GetAllJobs();
        // Get a specific Job by ID
        Job GetJobById(int id);
        void CreateJob(Job job);
        void UpdateJob(Job job);



        // For Offices
        // Get all of the Offices
        IEnumerable<Office> GetAllOffices();
        // Get a specific Job by ID
        Office GetOfficeById(int id);
        void CreateOffice(Office off);
        void UpdateOffice(Office off);


        //For Employees
        IEnumerable<Employee> GetAllEmployeesWithDetails();
        Employee GetEmployeeById(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);

    }
}
