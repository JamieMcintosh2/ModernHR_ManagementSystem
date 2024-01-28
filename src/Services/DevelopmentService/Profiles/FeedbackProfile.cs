using AutoMapper;
using DevelopmentService.Dtos;
using DevelopmentService.Models;

namespace DevelopmentService.Profiles
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<EmpFeedback, FeedbackReadDto>();
            CreateMap<FeedbackCreateDto, EmpFeedback>();
        }
    }
}
