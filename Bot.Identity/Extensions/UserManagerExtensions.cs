using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Core.Identity;

namespace Bot.Identity.Extensions
{
  public static class UserManagerExtensions
  {
    public static async Task<HavenAppUser> FindByClaimsCurrentUser(this UserManager<HavenAppUser> input, ClaimsPrincipal user)
    {
      var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
      return await input.Users.Include(z => z.UserPosition).SingleOrDefaultAsync(x => x.Email == email);
    }

    public static async Task<HavenAppUser> FindByClaimsPrincipleUserWithAddressAsync(this UserManager<HavenAppUser> input, ClaimsPrincipal user)
    {
      var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
      return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
    }


  }
}