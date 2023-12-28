namespace ProfileService.Dtos
{
    public class AddressReadDto
    {
        public int EmpId { get; set; }
        public int houseNum { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
