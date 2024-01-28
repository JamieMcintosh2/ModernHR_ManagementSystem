
namespace DevelopmentService.Dtos
{
    public class PerformanceReadDto
    {

        public int EmpId { get; set; }

        public string strengths { get; set; }

        public string weaknesses { get; set; }

        public DateTimeOffset reviewDate { get; set; }
    }
}
