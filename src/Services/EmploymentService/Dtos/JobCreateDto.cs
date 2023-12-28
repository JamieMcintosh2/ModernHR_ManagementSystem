using System.ComponentModel.DataAnnotations;

namespace EmploymentService.Dtos
{
    public class JobCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }
        [Required]
        [MaxLength(100)]
        public string Department { get; set; }
        [Required]
        public int salary { get; set; }
    }
}
