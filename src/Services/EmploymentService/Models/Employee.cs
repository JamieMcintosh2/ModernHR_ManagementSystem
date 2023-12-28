using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentService.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }

        [ForeignKey("Job")]
        public int jobId { get; set; }
        [ForeignKey("Office")]
        public int officeId { get; set; }


        //Navigation properties
        public Job Job { get; set; }
        public Office Office { get; set; }
    }
}
