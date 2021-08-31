using System.Threading.Tasks;
using Core.Identity;

namespace Infrastructure.Services.TokenService
{
  public interface ITokenService
  {
    Task<string> CreateToken(HavenAppUser user);
  }
}