using AutoMapper;
using jwtokencore.Api.Infrastructure.Identity;
using jwtokencore.Api.Core.Authentication;

namespace jwtokencore.Api.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser {UserName = u.UserName, Email = u.Email}).ForMember(au=>au.Id,opt=>opt.Ignore());
            CreateMap<AppUser, User>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).
                                       ForMember(dest=> dest.PasswordHash, opt=> opt.MapFrom(src=>src.PasswordHash)).
                                       ForAllOtherMembers(opt=>opt.Ignore());

        }
    }
}
