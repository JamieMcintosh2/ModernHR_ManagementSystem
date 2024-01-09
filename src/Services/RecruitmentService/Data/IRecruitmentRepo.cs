using RecruitmentService.Models;

namespace RecruitmentService.Data
{
    public interface IRecruitmentRepo
    {
        //Questions
        //Questions GetQuestionsByID(int ID);
        //Questions CreateQuestions(Questions q);
        Task<string> GenerateInterviewQuestions(Questions q);


        //Job Adverts
        Task<string> GenerateJobAdvert(JobAdvert jobAdObj);
    }
}
