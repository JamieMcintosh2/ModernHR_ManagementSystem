using System.ComponentModel.DataAnnotations;
using System;

namespace ProfileService.Dtos
{
    public class EmployeeCreateDto
    {
        //Dont need the Id as its being created by the Database
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
