using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Dtos;
using Core.Identity;
using Infrastructure.Services;
using Core.Dtos.Identity;

namespace WebAPI.Controllers
{

  [Authorize]
  public class AdminController : BaseApiController
  {
    private readonly UserManager<HavenAppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IRoleManagerService _roleManager;


    // 
    public AdminController(UserManager<HavenAppUser> userManager, IMapper mapper, IRoleManagerService roleManager)
    {
      _mapper = mapper;
      _userManager = userManager;
      _roleManager = roleManager;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Route("create")]
    public async Task<ActionResult<List<UserToReturnDto>>> CreateUser()
    {
      var users = await _userManager.Users.Include(x => x.Address).Include(z => z.UserRoles).ToListAsync();
      var usersToReturn = _mapper.Map<List<HavenAppUser>, List<UserToReturnDto>>(users);

      if (usersToReturn != null) return Ok(usersToReturn);
      return BadRequest("Не удалось получить список пользователей");
    }


    [HttpGet]
    // [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    [Route("users/all")]
    public async Task<ActionResult<List<UserToReturnDto>>> GetAllUsers()
    {
      var users = await _userManager.Users.Include(x => x.Address).Include(z => z.UserRoles).Include(p => p.UserPosition).ToListAsync();
      var usersToReturn = _mapper.Map<List<HavenAppUser>, List<UserToReturnDto>>(users);

      if (usersToReturn != null)
        return Ok(usersToReturn);
      return BadRequest("Не удалось получить список пользователей");
    }




  }

}