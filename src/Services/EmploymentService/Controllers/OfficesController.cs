using AutoMapper;
using EmploymentService.Data;
using EmploymentService.Dtos;
using EmploymentService.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmploymentService.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
       // private readonly MockRepo _Repo = new MockRepo();
        private readonly IEmploymentRepo _repository;
        private readonly IMapper _mapper;
        public OfficesController(IEmploymentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/office
        [HttpGet]
        public ActionResult<IEnumerable<OfficeReadDto>> GetAllOffices()
        {
            var officeItems = _repository.GetAllOffices();
            return Ok(_mapper.Map<IEnumerable<OfficeReadDto>>(officeItems));
        }
        //GET api/office/id
        [HttpGet("{id}", Name = "GetOfficeById")]
        public ActionResult <OfficeReadDto> GetOfficeById(int id)
        {
            var officeItem = _repository.GetOfficeById(id);
            if (officeItem != null)
            {
                return Ok(_mapper.Map<OfficeReadDto>(officeItem));
            }
            return NotFound();
        }

        //POST api/office
        //Uses the Create DTO to create an employee and returns back a ReadDto of the created employee
        [HttpPost]
        public ActionResult<OfficeCreateDto> CreateEmployee(OfficeCreateDto offCreateDto)
        {
            //CommandsProfile is where the Mapper is created
            //Using AutoMapper to do this
            //Mapping from a CreateDTO into a new empty Command object
            var officeModel = _mapper.Map<Office>(offCreateDto);
            _repository.CreateOffice(officeModel);

            _repository.saveChanges();

            //Converting our Model to a Read DTO as per our contract
            var offReadDto = _mapper.Map<OfficeReadDto>(officeModel);

            //Creates a created at route result, 201 response
            //Takes RouteName GetCommandByID
            //RouteValue basically the ID of the item.
            //And finally the content to form the content body, which is our commandReadDto
            return CreatedAtRoute(nameof(GetOfficeById), new { Id = offReadDto.Id }, offReadDto);

        }
        //PATCH api/offices/{id}
        [HttpPatch("{id}")]
        //ID is passed in from the client request via postman for example
        //Get the Patch document from request
        public ActionResult PartialOfficeUpdate(int id, JsonPatchDocument<OfficeUpdateDto> patchDoc)
        {
            //Checking if the resource exists
            var officeModelFromRepo = _repository.GetOfficeById(id);
            if (officeModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                //Generate a new empty employee update dto using data from repo model
                var officeToPatch = _mapper.Map<OfficeUpdateDto>(officeModelFromRepo);
                //Apply the patch to the new empty employee
                patchDoc.ApplyTo(officeToPatch, ModelState);
                //Validation to check everythings good
                if (!TryValidateModel(officeToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    //Now we want to update our model data
                    _mapper.Map(officeToPatch, officeModelFromRepo);
                    _repository.UpdateOffice(officeModelFromRepo);

                    //Sends our changes to the Database
                    _repository.saveChanges();
                    return NoContent();
                }

            }
        }
    }
}
