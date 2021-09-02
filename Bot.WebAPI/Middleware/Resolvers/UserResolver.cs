using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Core.Dtos;
using Core.Identity;
using Core.Models;
using Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace WebAPI.Helpers
{
  public class UserResolver : IValueResolver<Item, ItemDto, UserToReturnDto>
  {
    public UserResolver()
    {
    }

    private readonly UserManager<HavenAppUser> _userManager;
    private readonly IdentityContext _identityContext;
    private readonly IMapper _mapper;




    public UserResolver(
      UserManager<HavenAppUser> userManager,
      IdentityContext identityContext,
      IMapper mapper
    )
    {
      _userManager = userManager;
      _identityContext = identityContext;
      _mapper = mapper;
    }

    public UserToReturnDto Resolve(Item source, ItemDto destination, UserToReturnDto destMember, ResolutionContext context)
    {
      var userId = _userManager.FindByIdAsync(source.AuthorId.ToString()).Result.Id;
      var user = _identityContext.Users.Where(x => x.Id == userId).Include(u => u.UserPosition).FirstOrDefault();
      var userToReturn = _mapper.Map<HavenAppUser, UserToReturnDto>(user);
      return userToReturn;
    }
  }

}