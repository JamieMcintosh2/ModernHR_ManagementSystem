using AutoMapper;
using DevelopmentService.Dtos;
using DevelopmentService.Models;

namespace DevelopmentService.Profiles
{
    public class PerformanceHistoryProfile : Profile
    {
        public PerformanceHistoryProfile() 
        {
            CreateMap<PerformanceHistory, PerformanceHistoryReadDto>();
            //.ForMember(dest => dest.EmpPerformance, opt => opt.MapFrom(src => src.EmpPerformance));
            CreateMap<PerformanceHistoryCreateDto, PerformanceHistory>();
        }
    }
}
