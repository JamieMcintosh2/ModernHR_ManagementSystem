using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Dtos
{
    public class ContactsCreateDto
    {
        [Required]
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
    }
}
