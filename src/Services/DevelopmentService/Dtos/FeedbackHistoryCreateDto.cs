using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevelopmentService.Dtos
{
    public class FeedbackHistoryCreateDto
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Feedback { get; set; }

        [Required]
        public int OverallScore { get; set; }

        [Required]
        public DateTimeOffset FeedbackDate { get; set; }
    }
}
