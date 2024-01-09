using Microsoft.AspNetCore.Mvc;
using RecruitmentService.Data;
using RecruitmentService.Models;

namespace RecruitmentService.Controllers
{
    [Route("api/adverts")]
    [ApiController]
    public class JobAdvertController : ControllerBase
    {
        private readonly ILogger<JobAdvertController> _logger;
        private readonly IRecruitmentRepo _repo;

        public JobAdvertController(ILogger<JobAdvertController> logger, IRecruitmentRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        //POST api/adverts
        [HttpPost]
        public async Task<IActionResult> GenerateJobAdvert(JobAdvert advertObject)
        {
            var result = await _repo.GenerateJobAdvert(advertObject);
            // Converting the GenerativeAI response from basic text to a json object
            // This allows the data to be correctly returned when the API is called from web browser
            var responseObject = new { Result = result }; 
            return Ok(responseObject);
        }
    }
}
