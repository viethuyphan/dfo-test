using AutoMapper;
using DFO.Assignment.Domain.Entities;
using DFO.Assignment.Domain.Models.Users;

namespace DFO.Assignment.Domain.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreationModel, User>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
