using AutoMapper;
using hshmedstats.Application.Dtos;
using hshmedstats.Web.Models.User;

namespace hshmedstats.Web.Mapper
{
    public class UserViewProfile:Profile
    {
        public UserViewProfile()
        {
            CreateMap<UserViewModel, UserDto>();
            CreateMap<UserDto, UserViewModel>();
        }
    }
}
