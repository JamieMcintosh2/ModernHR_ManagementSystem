using AutoMapper;
using DevelopmentService.Data;
using DevelopmentService.Dtos;
using DevelopmentService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentService.Controllers
{
    [Route("api/performanceHistory")]
    [ApiController]
    public class PerformanceHistoryController : ControllerBase
    {
        private readonly IDevelopmentRepo _repo;
        private readonly IMapper _mapper;

        public PerformanceHistoryController(IDevelopmentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/performanceHistory/2
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PerformanceHistory>> GetPerformanceHistoryForEmployee(int id)
        {
            var performanceItems = _repo.GetPerformanceHistoryForEmployee(id);
            //Console.WriteLine(performanceItems);
            return Ok(_mapper.Map<IEnumerable<PerformanceHistoryReadDto>>(performanceItems));
        }
        /*
        //GET api/performance/2
        [HttpGet("{id}", Name = "GetPerformanceById")]
        public ActionResult<EmpPerformance> GetPerformanceById(int id)
        {
            var perfItem = _repo.GetPerformanceById(id);
            if (perfItem != null)
            {
                // return Ok(_mapper.Map<JobReadDto>(jobItem));
                return Ok(_mapper.Map<PerformanceReadDto>(perfItem));
            }
            return NotFound();
        }*/

        //POST api/performance
        //Uses the Create DTO to create an employee and returns back a ReadDto of the created employee
        
        [HttpPost]
        public ActionResult<PerformanceHistoryCreateDto> CreatePerformanceHistory(PerformanceHistoryCreateDto perfHistCreateDto)
        {
            //CommandsProfile is where the Mapper is created
            //Using AutoMapper to do this
            //Mapping from a CreateDTO into a new empty Command object
            var performanceModel = _mapper.Map<PerformanceHistory>(perfHistCreateDto);
            _repo.CreatePerformanceHistory(performanceModel);

            _repo.SaveChanges();

            //Converting our Model to a Read DTO as per our contract
            var perfReadDto = _mapper.Map<PerformanceHistoryReadDto>(performanceModel);

            //Creates a created at route result, 201 response
            //Takes RouteName GetCommandByID
            //RouteValue basically the ID of the item.
            //And finally the content to form the content body, which is our commandReadDto
            return Ok();

        }
    }
}

