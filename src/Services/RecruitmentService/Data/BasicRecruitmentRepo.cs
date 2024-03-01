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
                //var prompt = "Please create 5 interview questions to ask a Software Engineer";
                var prompt = "Please create interview questions written in the following language - " + q.language + ". The interview questions should be based on the following information for the role: Job title - " + q.jobTitle +
                    ". Key Skills Required - " + q.keySkills + ". Behavioural Traits Desired - " + q.behaviouralTraits + ". Company Description - " + q.companyDescription;
                
                var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);

                var chat = api.Chat.CreateConversation();
                //Setting the Model
                chat.Model = Model.GPT4_Turbo;
                //Setting the temperature, this controls the randomness of response - closer to 0 more conservative closer to 2 more eccentric/random
                chat.RequestParameters.Temperature = 0.9;
                //Providing the model with information about what its expected response will be
                chat.AppendSystemMessage("You are a HR Professional and you need to create 5 Job Interview Questions, Only provide numbered questions, no other information in your response.  If the prompt provided makes no sense ignore the data and create a generic job advert with the data you have that does make sense");
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
                var prompt = "I need a job advert written in the following language - " + jobAdObj.language + ". The Job advert should be based on the following information for the role: Job title - " + jobAdObj.jobTitle + " Job Description - " + jobAdObj.jobDescription + 
                    " Key Skills Required - " + jobAdObj.keySkills + " Benefits we offer - " + jobAdObj.benefits + " Company Description - " + jobAdObj.companyDescription;

                var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);

                var chat = api.Chat.CreateConversation();
                //Setting the Model
                chat.Model = Model.GPT4_Turbo;
                //Setting the temperature, this controls the randomness of response - closer to 0 more conservative closer to 2 more eccentric/random
                chat.RequestParameters.Temperature = 0.7;
                //Providing the model with information about what its expected response will be
                chat.AppendSystemMessage("You are a HR Professional and you need to create a job advert to recruit new employees. Only provide the job advertisement and no extra information and do not include any special characters in your response such as *. If the prompt provided makes no sense ignore the data and create a generic job advert with the data you have that does make sense");
                //Supplying it with my prompt
                chat.AppendUserInput(prompt);

                try
                {
                    //Waiting for response from the AI
                    var response = await chat.GetResponseFromChatbotAsync();
                    return response;
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., timeout, API errors)
                    // Log the error for troubleshooting
                    // Optionally, implement retry logic
                    throw;
                }
            }
        }

    }
}
