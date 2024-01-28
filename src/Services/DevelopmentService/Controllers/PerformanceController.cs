using AutoMapper;
using DevelopmentService.Data;
using DevelopmentService.Dtos;
using DevelopmentService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentService.Controllers
{
    [Route("api/performance")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly IDevelopmentRepo _repo;
        private readonly IMapper _mapper;

        public PerformanceController(IDevelopmentRepo repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }

        //private readonly TestRepo _repo = new TestRepo();
        [HttpGet]
        public ActionResult<IEnumerable<EmpPerformance>> GetAllPerformance()
        {
            var performanceItems = _repo.GetAllPerformance();
            return Ok(_mapper.Map<IEnumerable<PerformanceReadDto>>(performanceItems));
        }
        //GET api/performance/2
        [HttpGet("{id}", Name ="GetPerformanceById")]
        public ActionResult <EmpPerformance> GetPerformanceById(int id)
        {
            var perfItem = _repo.GetPerformanceById(id);
            if (perfItem != null)
            {
               // return Ok(_mapper.Map<JobReadDto>(jobItem));
               return Ok(_mapper.Map<PerformanceReadDto>(perfItem));
            }
            return NotFound();
        }

        //POST api/performance
        //Uses the Create DTO to create an employee and returns back a ReadDto of the created employee
        [HttpPost]
        public ActionResult<PerformanceCreateDto> CreatePerformance(PerformanceCreateDto perfCreateDto)
        {
            //CommandsProfile is where the Mapper is created
            //Using AutoMapper to do this
            //Mapping from a CreateDTO into a new empty Command object
            var performanceModel = _mapper.Map<EmpPerformance>(perfCreateDto);
            _repo.CreatePerformance(performanceModel);

            _repo.SaveChanges();

            //Converting our Model to a Read DTO as per our contract
            var perfReadDto = _mapper.Map<PerformanceReadDto>(performanceModel);

            //Creates a created at route result, 201 response
            //Takes RouteName GetCommandByID
            //RouteValue basically the ID of the item.
            //And finally the content to form the content body, which is our commandReadDto
            return CreatedAtRoute(nameof(GetPerformanceById), new { Id = perfReadDto.EmpId }, perfReadDto);

        }
    }
}
