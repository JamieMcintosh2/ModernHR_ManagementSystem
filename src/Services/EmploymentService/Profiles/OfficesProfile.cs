using EmploymentService.Dtos;
using AutoMapper;
using EmploymentService.Models;

namespace EmploymentService.Profiles
{
    public class OfficesProfile : Profile
    {
        public OfficesProfile()
        {
            CreateMap<Office, OfficeReadDto>();
            //Map is flipped from map for reading because we use a create dto to map to the domain
            CreateMap<OfficeCreateDto, Office>();
            CreateMap<OfficeUpdateDto, Office>();
            CreateMap<Office, OfficeUpdateDto>();
        }
    }
}
