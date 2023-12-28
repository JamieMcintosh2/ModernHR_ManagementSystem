using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Models
{
    public class EmergencyContact
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        [Required]
        [MaxLength(50)]
        public string fName { get; set; }
        [Required]
        [MaxLength(50)]
        public string lName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Relationship { get; set; }
        [Required]
        [MaxLength(50)]
        public string pNumber { get; set; }


        // Navigation property for the Employee
        public Employee Employee { get; set; }
    }
}
