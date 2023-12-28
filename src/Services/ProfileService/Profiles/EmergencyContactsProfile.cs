using AutoMapper;
using ProfileService.Dtos;
using ProfileService.Models;

namespace ProfileService.Profiles
{
    public class EmergencyContactsProfile : Profile
    {
        public EmergencyContactsProfile() 
        { 
            CreateMap<EmergencyContact, ContactsReadDto>();
            //Map is flipped from map for reading because we use a create dto to map to the domain
            CreateMap<ContactsCreateDto, EmergencyContact>();
            CreateMap<ContactsUpdateDto, EmergencyContact>();

            CreateMap<EmergencyContact, ContactsUpdateDto>();
        }
        
    }
}
