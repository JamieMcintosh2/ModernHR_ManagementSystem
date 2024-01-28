using System.ComponentModel.DataAnnotations;

namespace DevelopmentService.Dtos
{
    public class PerformanceHistoryCreateDto
    {

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string Strengths { get; set; }

        [Required]
        public string Weaknesses { get; set; }

        [Required]
        public DateTimeOffset ReviewDate { get; set; }
    }
}
