

namespace DevelopmentService.Dtos
{
    public class FeedbackHistoryReadDto
    {

        public int Id { get; set; }

        public int EmployeeId { get; set; }


        public string Feedback { get; set; }


        public int OverallScore { get; set; }

        public DateTimeOffset FeedbackDate { get; set; }
    }
}
