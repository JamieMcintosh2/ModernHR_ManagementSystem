using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevelopmentService.Models
{
    public class FeedbackHistory
    {
        [Key]
        [Required]
        public int Id { get; set; }

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
