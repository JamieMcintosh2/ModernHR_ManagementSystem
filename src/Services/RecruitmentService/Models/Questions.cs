namespace RecruitmentService.Models
{
    public class Questions
    {
        public int id {  get; set; }
        public string jobTitle { get; set; }
        public string keySkills { get; set; }
        public string behaviouralTraits { get; set; } //desired behavioural traits leadership, teamworking etc.
        public string interviewFormat { get; set; } //Technical assessment, one-on-one etc.
    }
}
