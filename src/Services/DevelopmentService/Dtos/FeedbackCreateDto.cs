using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevelopmentService.Dtos
{
    public class FeedbackCreateDto
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }

        [Required]
        [MaxLength(5000)]
        public string feedback { get; set; }
        [Required]
        public int overallScore { get; set; }

        public DateTimeOffset feedbackDate { get; set; }
    }
}
