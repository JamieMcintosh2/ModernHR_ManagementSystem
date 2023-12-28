using AutoMapper;
using ProfileService.Dtos;
using ProfileService.Models;
using System;

namespace ProfileService.Profiles
{
    //Profiles created for each domain object
    public class EmployeeProfiles : Profile
    {
        public EmployeeProfiles()
        {
            //Dont want to reveal Employee Date of Birth to client so when mapping changing it to Age
            // Source -> Destination
            CreateMap<Employee, EmployeeReadDto>()
            .ForMember(
                dest => dest.Age,
                 opt => opt.MapFrom(src => CalculateAge(src.DOB))
            );

            //Map is flipped from map for reading because we use a create dto to map to the domain
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();

            CreateMap<Employee, EmployeeUpdateDto>();
        }

        // Method to calculate age based on DOB
        private static int CalculateAge(DateTimeOffset dob)
        {
            var today = DateTimeOffset.UtcNow;
            var age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;
            return age;
        }
    }
}
