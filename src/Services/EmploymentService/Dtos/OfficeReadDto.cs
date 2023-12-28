using System.ComponentModel.DataAnnotations;

namespace EmploymentService.Dtos
{
    public class OfficeReadDto
    {

        public int Id { get; set; }

        public int BuildingNum { get; set; }

        public string Street { get; set; }

        public string Postcode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}

