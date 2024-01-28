using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevelopmentService.Models
{
    public class EmpPerformance
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }
        [Required]
        public string strengths { get; set; }
        [Required]
        public string weaknesses { get; set; }

        public DateTimeOffset reviewDate { get; set; }




        public EmpPerformance()
        {
            // Set default value for reviewDate to today's date
            reviewDate = DateTimeOffset.Now.Date;
        }
    }
}
