using AutoMapper;
using Core.Dtos;
using Core.Identity;

namespace WebAPI.Helpers
{
  public class AutoMapperProfiles : Profile
  {

    public AutoMapperProfiles()
    {
      CreateMap<AppUser, UserToReturnDto>()
        .ForMember(d => d.PictureUrl, m => m.MapFrom(s => s.PictureUrl))
        .ForMember(d => d.PictureUrl, m => m.MapFrom<UrlPictureForUserReslover>())
        .ForMember(d => d.UserRoles, m => m.MapFrom<UserRolesReslover>());


    }



  }
}