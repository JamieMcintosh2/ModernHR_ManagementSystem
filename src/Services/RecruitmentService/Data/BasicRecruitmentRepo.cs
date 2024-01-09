using OpenAI_API.Completions;
using OpenAI_API.Models;
using RecruitmentService.Configurations;
using RecruitmentService.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RecruitmentService.Data
{
    public class BasicRecruitmentRepo : IRecruitmentRepo
    {
        private readonly OpenAIConfig _openAIConfig;
        public BasicRecruitmentRepo(OpenAIConfig openAIConfig)
        {
            _openAIConfig = openAIConfig;
        }

        public async Task<string> GenerateInterviewQuestions(Questions q)
        {
            if (q == null)
            {
                throw new ArgumentNullException(nameof(q));
            }
            else
            {
                //var prompt = "Please create 3 interview questions to ask a Software Engineer";
                var prompt = "Please create interview questions based on the following information for the role: \n Job title - " + q.jobTitle +
                    " \n Key Skills Required - " + q.keySkills + " \n Behavioural Traits Desired - " + q.behaviouralTraits + " \n Format of the Interview - " + q.interviewFormat;
                
                var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);

                var chat = api.Chat.CreateConversation();
                //Setting the Model
                chat.Model = Model.GPT4_Turbo;
                //Setting the temperature, this controls the randomness of response - closer to 0 more conservative closer to 2 more eccentric/random
                chat.RequestParameters.Temperature = 0.1;
                //Providing the model with information about what its expected response will be
                chat.AppendSystemMessage("You are a HR Professional and you need to create 3 Job Interview Questions, Only provide numbered questions, no other information in your response");
                //Supplying it with my prompt
                chat.AppendUserInput(prompt);
                //Waiting for response from the AI
                var response = await chat.GetResponseFromChatbotAsync();
                return response;

            }
        }

        public async Task<string> GenerateJobAdvert(JobAdvert jobAdObj)
        {
            if (jobAdObj == null)
            {
                throw new ArgumentNullException(nameof(jobAdObj));
            }
            else
            {
                var prompt = "I need a job advert based on the following information for the role: \n Job title - " + jobAdObj.jobTitle + "\n Job Description - " + jobAdObj.jobDescription + 
                    "\n Key Skills Required - " + jobAdObj.keySkills + "\n Benefits we offer - " + jobAdObj.benefits;

                var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);

                var chat = api.Chat.CreateConversation();
                //Setting the Model
                chat.Model = Model.GPT4_Turbo;
                //Setting the temperature, this controls the randomness of response - closer to 0 more conservative closer to 2 more eccentric/random
                chat.RequestParameters.Temperature = 0.1;
                //Providing the model with information about what its expected response will be
                chat.AppendSystemMessage("You are a HR Professional and you need to create a job advert to recruit new employees. Only provide the job advertisement and no extra information and do not include any special characters in your response such as *");
                //Supplying it with my prompt
                chat.AppendUserInput(prompt);
                //Waiting for response from the AI
                var response = await chat.GetResponseFromChatbotAsync();
                return response;
            }
        }

    }
}
