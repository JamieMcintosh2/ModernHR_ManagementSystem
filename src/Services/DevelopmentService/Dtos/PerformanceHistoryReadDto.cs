using DevelopmentService.Models;

namespace DevelopmentService.Dtos
{
    public class PerformanceHistoryReadDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public DateTimeOffset ReviewDate { get; set; }

        // Include the navigation property
        //public EmpPerformance EmpPerformance { get; set; }
    }
}
