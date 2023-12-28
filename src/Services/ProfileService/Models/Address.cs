using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileService.Models
{
    public class Address
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        [Required]
        [MaxLength(5)]
        public int houseNum { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        [MaxLength (10)]
        public string Postcode { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        // Navigation property for the Employee
        public Employee Employee { get; set; }
    }
}
