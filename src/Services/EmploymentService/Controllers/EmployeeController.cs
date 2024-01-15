using AutoMapper;
using EmploymentService.Data;
using EmploymentService.Dtos;
using EmploymentService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace EmploymentService.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // private readonly MockRepo _Repo = new MockRepo();
        private readonly IEmploymentRepo _repository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmploymentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployeesWithDetails()
        {
            var employeeDetails = _repository.GetAllEmployeesWithDetails();
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employeeDetails));
        }

        //GET api/employees/{id}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<JobReadDto> GetEmployeeById(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(_mapper.Map<EmployeeReadDto>(employee));
            }
            return NotFound();
        }

        //POST api/employees
        //Uses the Create DTO to create an employee and returns back a ReadDto of the created employee
        [HttpPost]
        public ActionResult<EmployeeCreateDto> CreateEmployee(EmployeeCreateDto empCreateDto)
        {
            try
            {
                //AddressProfile is where the Mapper is created
                //Using AutoMapper to do this
                //Mapping from a CreateDTO into a new empty Address object
                var empModel = _mapper.Map<Employee>(empCreateDto);
                _repository.CreateEmployee(empModel);

                _repository.saveChanges();

                //Converting our Model to a Read DTO as per our contract
                var empReadDto = _mapper.Map<EmployeeReadDto>(empModel);

                //Creates a created at route result, 201 response
                //Takes RouteName GetAddressByID
                //RouteValue basically the ID of the item.
                //And finally the content to form the content body, which is our addReadDto
                return CreatedAtRoute(nameof(GetEmployeeById), new { Id = empReadDto.EmpId }, empReadDto);
            }
            // If the client enters an address and ID which does not link to an employee Catches the error and returns a 404 Not Found Messsage telling them the employee doesnt exist
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        //PATCH api/employees/{id}
        [HttpPatch("{id}")]
        //ID is passed in from the client request via postman for example
        //Get the Patch document from request
        public ActionResult<EmployeeReadDto> PartialEmployeeUpdate(int id, JsonPatchDocument<EmployeeUpdateDto> patchDoc)
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
                    var updatedEmployeeDto = _mapper.Map<EmployeeReadDto>(_repository.GetEmployeeById(id));
                    return Ok(updatedEmployeeDto);
                }

            }
        }
    }
}
