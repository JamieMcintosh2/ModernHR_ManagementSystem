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

        //GET api/questions/2
        [HttpGet("{ID}")]
        public ActionResult<Questions> GetQuestionsByID(int ID)
        {
            var questionsItem = _repo.GetQuestionsByID(ID);
            if (questionsItem != null)
            {
                return Ok(questionsItem);
            }
            return NotFound();
        }
        //POST api/questions

        [HttpPost]
        public async Task<IActionResult> GenerateInterviewQuestions(Questions questionObject)
        {
            var result = await _repo.GenerateInterviewQuestions(questionObject);
            return Ok(result);
        }

    }
}
