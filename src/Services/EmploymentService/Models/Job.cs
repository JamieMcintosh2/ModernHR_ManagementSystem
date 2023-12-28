using System.ComponentModel.DataAnnotations;

namespace EmploymentService.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
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
