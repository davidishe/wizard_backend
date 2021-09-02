using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Core.Dtos;
using Core.Identity;
using Core.Models;
using Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace WebAPI.Helpers
{

  public class UserBankOfficeResolver : IValueResolver<HavenAppUser, UserToReturnDto, string>
  {
    public UserBankOfficeResolver()
    {
    }

    private readonly UserManager<HavenAppUser> _userManager;
    private readonly DataContext _context;


    public UserBankOfficeResolver(
      UserManager<HavenAppUser> userManager,
      DataContext context
    )
    {
      _userManager = userManager;
      _context = context;
    }

    public string Resolve(HavenAppUser source, UserToReturnDto destination, string destMember, ResolutionContext context)
    {
      var officeName = _context.BankOffices.Where(x => x.Id == source.BankOfficeId).FirstOrDefault().Name;
      return officeName;
    }
  }

}