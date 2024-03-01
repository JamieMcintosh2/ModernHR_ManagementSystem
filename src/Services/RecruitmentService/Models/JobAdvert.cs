namespace RecruitmentService.Models
{
    public class JobAdvert
    {
        public string jobTitle { get; set; }
        public string keySkills { get; set; }
        public string jobDescription { get; set; }
        public string benefits { get; set; }
        public string companyDescription {  get; set; }
        public string language { get; set; }

        public JobAdvert() 
        {
            //Hardcoded company description which will be reused for every response
            companyDescription = "NexGen is a pioneering enterprise organization at the forefront of revolutionizing the global marketplace. Our commitment to innovation, customer-centricity, and cutting-edge technology sets us apart as a leader in the industry.";
        }

    }


}
