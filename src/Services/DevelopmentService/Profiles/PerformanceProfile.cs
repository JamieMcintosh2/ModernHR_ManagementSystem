using AutoMapper;
using DevelopmentService.Dtos;
using DevelopmentService.Models;

namespace DevelopmentService.Profiles
{
    public class PerformanceProfile : Profile
    {
        public PerformanceProfile()
        {
            CreateMap<EmpPerformance, PerformanceReadDto>();
            CreateMap<PerformanceCreateDto, EmpPerformance>();
        }
    }
}
