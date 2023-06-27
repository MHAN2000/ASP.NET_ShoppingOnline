using AutoMapper;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>().ForMember(dest => dest.Tickets, src => src.Ignore());
        }
    }
}
