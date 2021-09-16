using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Wizard.Identity.Extensions;
using Wizard.Identity.Services;
using Core.Dtos;
using Core.Dtos.Identity;
using Core.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{

  [Authorize]
  public class RoleController : BaseApiController
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IRoleManagerService _roleManager;


    // 
    public RoleController(UserManager<AppUser> userManager, IMapper mapper, IRoleManagerService roleManager)
    {
      _mapper = mapper;
      _userManager = userManager;
      _roleManager = roleManager;
    }



    [HttpGet]
    [AllowAnonymous]
    [Route("users/all")]
    public async Task<ActionResult<List<UserToReturnDto>>> GetAllUsers()
    {
      var users = await _userManager.Users.Include(x => x.Address).ToListAsync();
      var usersToReturn = _mapper.Map<List<AppUser>, List<UserToReturnDto>>(users);

      if (usersToReturn != null)
        return Ok(usersToReturn);
      return BadRequest("Не удалось получить список пользователей");
    }


    [HttpPost]
    // [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    [Route("add")]
    public async Task<ActionResult> AddRoleForUser([FromQuery] string role)
    {
      var user = await _userManager.FindByClaimsPrincipleUserWithAddressAsync(HttpContext.User);
      await _userManager.AddToRoleAsync(user, role);
      return Ok(200);
    }

    [HttpDelete]
    // [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    [Route("delete")]
    public async Task<ActionResult> DeleteRoleForUser([FromQuery] string role)
    {
      var user = await _userManager.FindByClaimsPrincipleUserWithAddressAsync(HttpContext.User);
      await _userManager.RemoveFromRoleAsync(user, role);
      return Ok(200);
    }

    [HttpPost]
    // [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    [Route("change")]
    public async Task<ActionResult> ChangeUserRole([FromQuery] string userId, UserRolesDto roles)
    {
      await _roleManager.ChangeUserRoles(roles.UserRoles, userId);
      return Ok(200);
    }

  }

}