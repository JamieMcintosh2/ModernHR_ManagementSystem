using AutoMapper;
using EmploymentService.Dtos;
using EmploymentService.Models;
using System.Net;

namespace EmploymentService.Profiles
{
    public class JobsProfile : Profile
    {
        public JobsProfile()
        {
            CreateMap<Job, JobReadDto>();
            //Map is flipped from map for reading because we use a create dto to map to the domain
            CreateMap<JobCreateDto, Job>();
            CreateMap<JobUpdateDto, Job>();
            CreateMap<Job, JobUpdateDto>();
        }
    }
}
