using AutoMapper;
using EmploymentService.Data;
using EmploymentService.Dtos;
using EmploymentService.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmploymentService.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
       // private readonly MockRepo _Repo = new MockRepo();
        private readonly IEmploymentRepo _repository;
        private readonly IMapper _mapper;

        public JobsController(IEmploymentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
         }

        //GET api/jobs
        [HttpGet]
        public ActionResult<IEnumerable<JobReadDto>> GetAllJobs()
        {
            var jobItems = _repository.GetAllJobs();
            return Ok(_mapper.Map<IEnumerable<JobReadDto>>(jobItems));
        }
        [HttpGet("{id}", Name = "GetJobById")]
        public ActionResult<JobReadDto> GetJobById(int id)
        {
            var jobItem = _repository.GetJobById(id);
            if(jobItem != null)
            {
                return Ok(_mapper.Map<JobReadDto>(jobItem));
            }
            return NotFound();
        }


        //POST api/jobs
        //Uses the Create DTO to create an employee and returns back a ReadDto of the created employee
        [HttpPost]
        public ActionResult<JobCreateDto> CreateJob(JobCreateDto jobCreateDto)
        {
            //CommandsProfile is where the Mapper is created
            //Using AutoMapper to do this
            //Mapping from a CreateDTO into a new empty Command object
            var jobModel = _mapper.Map<Job>(jobCreateDto);
            _repository.CreateJob(jobModel);

            _repository.saveChanges();

            //Converting our Model to a Read DTO as per our contract
            var jobReadDto = _mapper.Map<JobReadDto>(jobModel);

            //Creates a created at route result, 201 response
            //Takes RouteName GetCommandByID
            //RouteValue basically the ID of the item.
            //And finally the content to form the content body, which is our commandReadDto
            return CreatedAtRoute(nameof(GetJobById), new { Id = jobReadDto.Id }, jobReadDto);

        }

        //PATCH api/jobs/{id}
        [HttpPatch("{id}")]
        //ID is passed in from the client request via postman for example
        //Get the Patch document from request
        public ActionResult PartialJobUpdate(int id, JsonPatchDocument<JobUpdateDto> patchDoc)
        {
            //Checking if the resource exists
            var jobModelFromRepo = _repository.GetJobById(id);
            if (jobModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                //Generate a new empty employee update dto using data from repo model
                var jobToPatch = _mapper.Map<JobUpdateDto>(jobModelFromRepo);
                //Apply the patch to the new empty employee
                patchDoc.ApplyTo(jobToPatch, ModelState);
                //Validation to check everythings good
                if (!TryValidateModel(jobToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    //Now we want to update our model data
                    _mapper.Map(jobToPatch, jobModelFromRepo);
                    _repository.UpdateJob(jobModelFromRepo);

                    //Sends our changes to the Database
                    _repository.saveChanges();
                    return NoContent();
                }

            }
        }
    }
}
