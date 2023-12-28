using AutoMapper;
using ProfileService.Dtos;
using ProfileService.Models;

namespace ProfileService.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile() 
        {
            CreateMap<Address, AddressReadDto>();
            //Map is flipped from map for reading because we use a create dto to map to the domain
            CreateMap<AddressCreateDto, Address>();
            CreateMap<AddressUpdateDto, Address>();

            CreateMap<Address, AddressUpdateDto>();
        }
    }
}
