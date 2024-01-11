using AutoMapper;
using hshmedstats.Application.Dtos;
using hshmedstats.Domain;


namespace hshmedstats.Application.Mappers
{
    public sealed class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();
        }
    }
}
