using System.ComponentModel.DataAnnotations;

namespace EmploymentService.Models
{
    public class Office
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public int BuildingNum { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        [MaxLength(10)]
        public string Postcode { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
