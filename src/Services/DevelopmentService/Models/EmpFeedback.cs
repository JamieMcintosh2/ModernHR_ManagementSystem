using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevelopmentService.Models
{
    public class EmpFeedback
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }

        [Required]
        [MaxLength(5000)]
        public string feedback {  get; set; }
        [Required]
        public int overallScore { get; set; }
       
        public DateTimeOffset feedbackDate {  get; set; }



        public EmpFeedback()
        {
            feedbackDate = DateTimeOffset.Now.Date;
        }
    }
    
}
