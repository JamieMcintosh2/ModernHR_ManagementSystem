namespace EmploymentService.Dtos
{
    public class EmployeeReadDto
    {
        public int EmpId { get; set; }
        public JobReadDto Job { get; set; }
        public OfficeReadDto Office { get; set; }
    }
}
