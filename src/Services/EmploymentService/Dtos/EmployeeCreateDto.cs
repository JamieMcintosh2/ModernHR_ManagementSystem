using EmploymentService.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmploymentService.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }

        [ForeignKey("Job")]
        public int jobId { get; set; }
        [ForeignKey("Office")]
        public int officeId { get; set; }
    }
}
