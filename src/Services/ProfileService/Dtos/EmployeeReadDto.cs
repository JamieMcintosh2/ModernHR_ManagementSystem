using ProfileService.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Dtos
{
    public class EmployeeReadDto
    {

        public int Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
       // public DateTimeOffset DOB { get; set; }
        public string pNumber { get; set; }
        public int Age {  get; set; } //I dont want to share Date Of Birth as it could risk personal information so I display age instead. calculation performed in Profile

    }
}
