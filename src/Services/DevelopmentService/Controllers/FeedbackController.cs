using AutoMapper;
using DevelopmentService.Data;
using DevelopmentService.Dtos;
using DevelopmentService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentService.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IDevelopmentRepo _repo;
        private readonly IMapper _mapper;
        public FeedbackController(IDevelopmentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EmpFeedback>> GetAllFeedbackWithPerformance()
        {
            var feedbackItems = _repo.GetAllFeedbackWithPerformance();
            return Ok(_mapper.Map<IEnumerable<FeedbackReadDto>>(feedbackItems));
        }
        //GET api/feedback/2
        [HttpGet("{id}", Name = "GetFeedbackById")]
        public ActionResult<PerformanceReadDto> GetFeedbackById(int id)
        {
            var feedItem = _repo.GetFeedbackById(id);
            if (feedItem != null)
            {
                // return Ok(_mapper.Map<JobReadDto>(jobItem));
                return Ok(_mapper.Map<FeedbackReadDto>(feedItem));
            }
            return NotFound();
        }

        //POST api/performance
        //Uses the Create DTO to create an employee and returns back a ReadDto of the created employee
        [HttpPost]
        public ActionResult<FeedbackCreateDto> CreateFeedback(FeedbackCreateDto feedCreateDto)
        {
            var feedbackModel = _mapper.Map<EmpFeedback>(feedCreateDto);

            // Load the associated Performance entity here
            //feedbackModel.Performance = _repo.GetPerformanceById(feedCreateDto.performanceId);

            _repo.CreateFeedback(feedbackModel);
            _repo.SaveChanges();

            var feedReadDto = _mapper.Map<FeedbackReadDto>(feedbackModel);

            return CreatedAtRoute(nameof(GetFeedbackById), new { id = feedReadDto.EmpId }, feedReadDto);

        }
    }
}
