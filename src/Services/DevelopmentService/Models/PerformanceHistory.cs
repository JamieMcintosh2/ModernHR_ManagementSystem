using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevelopmentService.Models
{
    public class PerformanceHistory
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        [Required]
        public string Strengths { get; set; }

        [Required]
        public string Weaknesses { get; set; }

        [Required]
        public DateTimeOffset ReviewDate { get; set; }


    }
}
