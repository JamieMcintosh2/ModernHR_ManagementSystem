using Microsoft.AspNetCore.Mvc;
using RecruitmentService.Data;
using RecruitmentService.Models;

namespace RecruitmentService.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        //private readonly BasicRecruitmentRepo _basicRecruitmentRepo = new BasicRecruitmentRepo();
        private readonly ILogger<QuestionsController> _logger;
        private readonly IRecruitmentRepo _repo;
        //Constructor Dependency injection, Add more services in to the constructor, by adding them as an argument
        public QuestionsController(ILogger<QuestionsController> logger, IRecruitmentRepo repo)
        {
            _logger = logger;
            _repo = repo;

        }

        //POST api/questions
        [HttpPost]
        public async Task<IActionResult> GenerateInterviewQuestions(Questions questionObject)
        {
            var result = await _repo.GenerateInterviewQuestions(questionObject);
            // Converting the GenerativeAI response from basic text to a json object
            // This allows the data to be correctly returned when the API is called from web browser
            var responseObject = new { Result = result };
            return Ok(responseObject);
        }

    }
}
