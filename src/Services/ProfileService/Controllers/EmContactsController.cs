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
    [Route("api/emContacts")]
    [ApiController]
    public class EmContactsController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;
        private readonly IMapper _mapper;

        public EmContactsController(IEmployeeRepo repository, IMapper mapper)
        {
            //_Thing denotes it is a readonly field
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/emContacts/2
        [HttpGet("{id}", Name = "GetContactById")]
        public ActionResult<ContactsReadDto> GetContactById(int id)
        {
            var emergencyItem = _repository.GetContactById(id);
            if (emergencyItem != null)
            {
                return Ok(_mapper.Map<ContactsReadDto>(emergencyItem));
            }
            return NotFound();
        }


        //POST api/emContacts
        //Uses the Create DTO to create an employee and returns back a ReadDto of the created employee
        [HttpPost]
        public ActionResult<ContactsCreateDto> CreateContact(ContactsCreateDto emergCreateDto)
        {
            try
            {
                //AddressProfile is where the Mapper is created
                //Using AutoMapper to do this
                //Mapping from a CreateDTO into a new empty Address object
                var contactsModel = _mapper.Map<EmergencyContact>(emergCreateDto);
                _repository.CreateContact(contactsModel);

                _repository.saveChanges();

                //Converting our Model to a Read DTO as per our contract
                var addReadDto = _mapper.Map<ContactsReadDto>(contactsModel);

                //Creates a created at route result, 201 response
                //Takes RouteName GetAddressByID
                //RouteValue basically the ID of the item.
                //And finally the content to form the content body, which is our addReadDto
                return CreatedAtRoute(nameof(GetContactById), new { Id = addReadDto.EmpId }, addReadDto);
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


        //PATCH api/emContacts/{id}
        [HttpPatch("{id}")]
        //ID is passed in from the client request via postman for example
        //Get the Patch document from request
        public ActionResult PartialContactsUpdate(int id, JsonPatchDocument<ContactsUpdateDto> patchDoc)
        {
            //Checking if the resource exists
            try
            {
                var emergContactModelFromRepo = _repository.GetContactById(id);
                if (emergContactModelFromRepo == null)
                {
                    return NotFound();
                }
                else
                {
                    //Generate a new empty employee update dto using data from repo model
                    var emergContactToPatch = _mapper.Map<ContactsUpdateDto>(emergContactModelFromRepo);
                    //Apply the patch to the new empty employee
                    patchDoc.ApplyTo(emergContactToPatch, ModelState);
                    //Validation to check everythings good
                    if (!TryValidateModel(emergContactToPatch))
                    {
                        return ValidationProblem(ModelState);
                    }
                    else
                    {
                        //Now we want to update our model data
                        _mapper.Map(emergContactToPatch, emergContactModelFromRepo);
                        _repository.UpdateContact(emergContactModelFromRepo);

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
    }
}
