using AutoMapper;
using DevelopmentService.Data;
using DevelopmentService.Dtos;
using DevelopmentService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentService.Controllers
{
    [Route("api/feedbackHistory")]
    [ApiController]
    public class FeedbackHistoryController : ControllerBase
    {
        private readonly IDevelopmentRepo _repo;
        private readonly IMapper _mapper;

        public FeedbackHistoryController(IDevelopmentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        //GET api/feedbackHistory/2
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FeedbackHistory>> GetFeedbackHistoryForEmployee(int id)
        {
            var feedbackItems = _repo.GetFeedbackHistoryForEmployee(id);
            //Console.WriteLine(performanceItems);
            return Ok(_mapper.Map<IEnumerable<FeedbackHistoryReadDto>>(feedbackItems));
        }

        [HttpPost]
        public ActionResult<FeedbackHistoryCreateDto> CreateFeedbackHistory(FeedbackHistoryCreateDto feedHistCreateDto)
        {
            //CommandsProfile is where the Mapper is created
            //Using AutoMapper to do this
            //Mapping from a CreateDTO into a new empty Command object
            var feedbackModel = _mapper.Map<FeedbackHistory>(feedHistCreateDto);
            _repo.CreateFeedbackHistory(feedbackModel);

            _repo.SaveChanges();

            //Converting our Model to a Read DTO as per our contract
            var feedReadDto = _mapper.Map<FeedbackHistoryReadDto>(feedbackModel);

            //Creates a created at route result, 201 response
            //Takes RouteName GetCommandByID
            //RouteValue basically the ID of the item.
            //And finally the content to form the content body, which is our commandReadDto
            return Ok();

        }
    }
}
