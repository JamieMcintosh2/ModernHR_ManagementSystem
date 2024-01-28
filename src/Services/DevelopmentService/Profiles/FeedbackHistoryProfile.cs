using AutoMapper;
using DevelopmentService.Dtos;
using DevelopmentService.Models;

namespace DevelopmentService.Profiles
{
    public class FeedbackHistoryProfile : Profile
    {
        public FeedbackHistoryProfile() 
        {
            CreateMap<FeedbackHistory, FeedbackHistoryReadDto>();
            CreateMap<FeedbackHistoryCreateDto, FeedbackHistory>();

        }
    }
}
