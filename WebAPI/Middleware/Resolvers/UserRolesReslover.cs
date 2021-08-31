using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Core.Dtos;
using Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace WebAPI.Helpers
{
  public class UserRolesReslover : IValueResolver<HavenAppUser, UserToReturnDto, IList<string>>
  {
    public UserRolesReslover()
    {
    }

    private readonly UserManager<HavenAppUser> _userManager;


    public UserRolesReslover(UserManager<HavenAppUser> userManager)
    {
      _userManager = userManager;
    }


    public IList<string> Resolve(HavenAppUser user, UserToReturnDto destination, IList<string> destMember, ResolutionContext context)
    {
      var roles = _userManager.GetRolesAsync(user).Result;
      return roles;
    }
  }

}