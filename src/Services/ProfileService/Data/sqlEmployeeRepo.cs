using Microsoft.EntityFrameworkCore;
using ProfileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ProfileService.Data
{
    public class sqlEmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext _context;
        //Dependency injection to get DB context
        public sqlEmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }

        public void CreateAddress(Address address)
        {
            //If null throw error
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            // Check if the associated employee exists before creating the address
            var employeeExists = _context.employees.Any(e => e.Id == address.EmpId);
            if (!employeeExists)
            {
                throw new ArgumentException("Employee does not exist", nameof(address.EmpId));
            }
            //Else emp passed in is not null, add it

            _context.addresses.Add(address);

        }

        public void CreateContact(EmergencyContact emergencyContact)
        {
            //If null throw error
            if (emergencyContact == null)
            {
                throw new ArgumentNullException(nameof(emergencyContact));
            }
            // Check if the associated employee exists before creating the Emergency Contact
            var employeeExists = _context.employees.Any(e => e.Id == emergencyContact.EmpId);
            if (!employeeExists)
            {
                throw new ArgumentException("Employee does not exist", nameof(emergencyContact.EmpId));
            }
            //Else emp passed in is not null, add it

            _context.emContacts.Add(emergencyContact);
        }

        public void CreateEmployee(Employee emp)
        {
            //If null throw error
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }
            //Else emp passed in is not null, add it
            else
            {
                _context.employees.Add(emp);
            }
        }

        public void DeleteAddress(Address address)
        {
            //If null throw error
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            //Else cmd passed in is not null, add it
            else
            {
                _context.addresses.Remove(address);
            }
        }

        public void DeleteEmployee(Employee emp)
        {
            //If null throw error
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }
            //Else cmd passed in is not null, add it
            else
            {
                _context.employees.Remove(emp);
            }
        }

        public Address GetAddressById(int empId)
        {
            return _context.addresses
                .Include(a => a.Employee)
                .FirstOrDefault(a => a.EmpId == empId);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.employees.ToList(); //Returning a list of all the employees from our DB context
        }

        public EmergencyContact GetContactById(int empId)
        {
            return _context.emContacts
                .Include(a => a.Employee)
                .FirstOrDefault(a => a.EmpId == empId);
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.employees.FirstOrDefault(e => e.Id == id);
        }

        public bool saveChanges()
        {
            //This method saves the changes in the database without this the changes wont be saved
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAddress(Address address)
        {
            //Check if ID entered exists
            var employeeExists = _context.employees.Any(e => e.Id == address.EmpId);
            if (!employeeExists)
            {
                throw new ArgumentException("Employee does not exist", nameof(address.EmpId));
            }
        }

        public void UpdateContact(EmergencyContact emergencyContact)
        {
            //nothing
        }

        public void UpdateEmployee(Employee emp)
        {
            //Nothing
        }
    }
}
