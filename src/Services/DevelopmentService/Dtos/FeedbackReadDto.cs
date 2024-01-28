using DevelopmentService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevelopmentService.Dtos
{
    public class FeedbackReadDto
    {
        public int EmpId { get; set; }


        public string feedback { get; set; }

        public int overallScore { get; set; }

        public DateTimeOffset feedbackDate { get; set; }

    }
}
