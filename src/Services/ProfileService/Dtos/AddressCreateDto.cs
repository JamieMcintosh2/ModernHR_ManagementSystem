using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Dtos
{
    public class AddressCreateDto
    {
        [Required]
        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        [Required]
        public int houseNum { get; set; }
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
