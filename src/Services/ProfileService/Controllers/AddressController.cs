using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Data;
using ProfileService.Dtos;
using ProfileService.Models;
using System;

namespace ProfileService.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;
        private readonly IMapper _mapper;

        //Constructor Dependency injection, Add more services in to the constructor, by adding them as an argument
        //IMapper, is service from Automapper
        public AddressController(IEmployeeRepo repository, IMapper mapper)
        {
            //_Thing denotes it is a readonly field
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/addresses/2
        [HttpGet("{id}", Name = "GetAddressById")]
        public ActionResult<AddressReadDto> GetAddressById(int id)
        {
            var addressItem = _repository.GetAddressById(id);
            if (addressItem != null)
            {
                return Ok(_mapper.Map<AddressReadDto>(addressItem));
            }
            return NotFound();
        }

        //POST api/addresses
        //Uses the Create DTO to create an employee and returns back a ReadDto of the created employee
        [HttpPost]
        public ActionResult<AddressCreateDto> CreateAddress(AddressCreateDto addCreateDto)
        {
            try
            {
                //AddressProfile is where the Mapper is created
                //Using AutoMapper to do this
                //Mapping from a CreateDTO into a new empty Address object
                var addressModel = _mapper.Map<Address>(addCreateDto);
                _repository.CreateAddress(addressModel);

                _repository.saveChanges();

                //Converting our Model to a Read DTO as per our contract
                var addReadDto = _mapper.Map<AddressReadDto>(addressModel);

                //Creates a created at route result, 201 response
                //Takes RouteName GetAddressByID
                //RouteValue basically the ID of the item.
                //And finally the content to form the content body, which is our addReadDto
                return CreatedAtRoute(nameof(GetAddressById), new { Id = addReadDto.EmpId }, addReadDto);
            }
            // If the client enters an address and ID which does not link to an employee Catches the error and returns a 404 Not Found Messsage telling them the employee doesnt exist
            catch(ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }


        }

        //PATCH api/addresses/{id}
        [HttpPatch("{id}")]
        //ID is passed in from the client request via postman for example
        //Get the Patch document from request
        public ActionResult PartialEmployeeUpdate(int id, JsonPatchDocument<AddressUpdateDto> patchDoc)
        {
            //Checking if the resource exists
            try
            {
                var addModelFromRepo = _repository.GetAddressById(id);
                if (addModelFromRepo == null)
                {
                    return NotFound();
                }
                else
                {
                    //Generate a new empty employee update dto using data from repo model
                    var addToPatch = _mapper.Map<AddressUpdateDto>(addModelFromRepo);
                    //Apply the patch to the new empty employee
                    patchDoc.ApplyTo(addToPatch, ModelState);
                    //Validation to check everythings good
                    if (!TryValidateModel(addToPatch))
                    {
                        return ValidationProblem(ModelState);
                    }
                    else
                    {
                        //Now we want to update our model data
                        _mapper.Map(addToPatch, addModelFromRepo);
                        _repository.UpdateAddress(addModelFromRepo);

                        //Sends our changes to the Database
                        _repository.saveChanges();
                        return NoContent();
                    }

                }
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


        //DELETE api/addresses/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            //Checking if the resource exists
            var addModelFromRepo = _repository.GetAddressById(id);
            if (addModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _repository.DeleteAddress(addModelFromRepo);
                _repository.saveChanges();

                return NoContent();
            }
        }
    }
}
