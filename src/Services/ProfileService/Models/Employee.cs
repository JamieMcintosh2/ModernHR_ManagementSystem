using System;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string fName { get; set; }
        [Required]
        [MaxLength(50)]
        public string lName { get; set; }
        [Required]
        public DateTimeOffset DOB { get; set; }
        [Required]
        [MaxLength(50)]
        public string pNumber { get; set; }
    }
}
