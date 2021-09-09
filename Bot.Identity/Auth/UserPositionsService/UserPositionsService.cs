using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Core.Domain;
using Core.Dtos;
using Core.Identity;
using Core.Models.Contracts;
using Core.Models.Identity;
using Core.Options;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bot.Identity.Database;

namespace Bot.Identity.Services
{
  public class UserPositionsService : IUserPositionsService
  {
    private readonly UserManager<HavenAppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IdentityContext _context;


    public UserPositionsService(
    UserManager<HavenAppUser> userManager,
    IdentityContext context,
    IMapper mapper)
    {
      _mapper = mapper;
      _userManager = userManager;
      _context = context;
    }

    public async Task<bool> ChangeItem(string[] roles, string userId)
    {
      var user = await _userManager.FindByIdAsync(userId);
      var userRoles = await _userManager.GetRolesAsync(user);
      await _userManager.RemoveFromRolesAsync(user, userRoles);
      IEnumerable<string> enumRoles = roles;
      await _userManager.AddToRolesAsync(user, enumRoles);
      return true;
    }

    public Task<List<UserPosition>> GetAll()
    {
      var positions = _context.UserPosition.ToListAsync();
      return positions;
    }

    public async Task<bool> AddEntityAsync(UserPosition userPosition)
    {
      var position = await _context.UserPosition.AddAsync(userPosition);
      if (position == null)
        return false;

      return true;

    }
  }
}