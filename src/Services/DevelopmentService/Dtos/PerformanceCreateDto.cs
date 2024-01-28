using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevelopmentService.Dtos
{
    public class PerformanceCreateDto
    {

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }
        [Required]
        public string strengths { get; set; }
        [Required]
        public string weaknesses { get; set; }

        public DateTimeOffset reviewDate { get; set; }

    }
}