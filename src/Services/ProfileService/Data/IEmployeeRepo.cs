using ProfileService.Models;
using System.Collections.Generic;

namespace ProfileService.Data
{
    // Interface used to define the operations available for Employee
    public interface IEmployeeRepo
    {
        bool saveChanges();
        // Get all of the employees
        IEnumerable<Employee> GetAllEmployees();
        // Get a specific employee by ID
        Employee GetEmployeeById(int id);
        //For creating a new employee
        void CreateEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(Employee emp);


        // For Addresses
        Address GetAddressById(int empId);
        void CreateAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(Address address);

        //For Emergency Contacts
        EmergencyContact GetContactById(int empId);
        void CreateContact(EmergencyContact emergencyContact);
        void UpdateContact(EmergencyContact emergencyContact);
    }
}
