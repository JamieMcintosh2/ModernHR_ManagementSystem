using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Data;
using ProfileService.Dtos;
using ProfileService.Models;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProfileService.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
       // private readonly MockRepo _Repo = new MockRepo();
        private readonly IEmployeeRepo _repository;
        private readonly IMapper _mapper;

        //Constructor Dependency injection, Add more services in to the constructor, by adding them as an argument
        //IMapper, is service from Automapper
        public EmployeesController(IEmployeeRepo repository, IMapper mapper)
        {
            //_Thing denotes it is a readonly field
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/employees
        //public ActionResult <IEnumerable<Employee>> GetAllEmployees() //Used for returning enumeration of domain objects
        [HttpGet]
        public ActionResult <IEnumerable<EmployeeReadDto>> GetAllEmployees()
        {
            var employeesItems = _repository.GetAllEmployees();
            //Could do this to return domain objects
            //return Ok(employeesItems);

            //But this way uses Dtos, it's nicer
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employeesItems));
        }
        //GET api/employees/2
        // public ActionResult<Employee> GetEmployeeByID(int id) for returning domain object
        [HttpGet("{id}", Name="GetEmployeeByID")]
        public ActionResult<EmployeeReadDto> GetEmployeeByID(int id)
        {
            var employeeItem = _repository.GetEmployeeById(id);
            if(employeeItem != null) 
            {
                //For returning Domain Object
                //return Ok(employeeItem);
                //For returning Dto
                return Ok(_mapper.Map<EmployeeReadDto>(employeeItem));
            }
            return NotFound();
        }

        //POST api/employees
        //Uses the Create DTO to create an employee and returns back a ReadDto of the created employee
        [HttpPost]
        public ActionResult<EmployeeCreateDto> CreateEmployee(EmployeeCreateDto empCreateDto)
        {
            //CommandsProfile is where the Mapper is created
            //Using AutoMapper to do this
            //Mapping from a CreateDTO into a new empty Command object
            var employeeModel = _mapper.Map<Employee>(empCreateDto);
            _repository.CreateEmployee(employeeModel);
            
            _repository.saveChanges();

            //Converting our Model to a Read DTO as per our contract
            var empReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

            //Creates a created at route result, 201 response
            //Takes RouteName GetCommandByID
            //RouteValue basically the ID of the item.
            //And finally the content to form the content body, which is our commandReadDto
             return CreatedAtRoute(nameof(GetEmployeeByID), new { Id = empReadDto.Id }, empReadDto);

        }


        //PATCH api/employees/{id}
        [HttpPatch("{id}")]
        //ID is passed in from the client request via postman for example
        //Get the Patch document from request
        public ActionResult PartialEmployeeUpdate(int id, JsonPatchDocument<EmployeeUpdateDto> patchDoc)
        {
            //Checking if the resource exists
            var empModelFromRepo = _repository.GetEmployeeById(id);
            if (empModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                //Generate a new empty employee update dto using data from repo model
                var empToPatch = _mapper.Map<EmployeeUpdateDto>(empModelFromRepo);
                //Apply the patch to the new empty employee
                patchDoc.ApplyTo(empToPatch, ModelState);
                //Validation to check everythings good
                if (!TryValidateModel(empToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    //Now we want to update our model data
                    _mapper.Map(empToPatch, empModelFromRepo);
                    _repository.UpdateEmployee(empModelFromRepo);

                    //Sends our changes to the Database
                    _repository.saveChanges();
                    return NoContent();
                }

            }
        }

        //DELETE api/employees/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            //Checking if the resource exists
            var empModelFromRepo = _repository.GetEmployeeById(id);
            if (empModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _repository.DeleteEmployee(empModelFromRepo);
                _repository.saveChanges();

                return NoContent();
            }
        }
    }
}
