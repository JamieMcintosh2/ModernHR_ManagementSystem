using System.ComponentModel.DataAnnotations;

namespace EmploymentService.Dtos
{
    public class OfficeCreateDto
    {
        [Required]
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
