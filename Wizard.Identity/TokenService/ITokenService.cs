using System.Threading.Tasks;
using Core.Identity;

namespace Wizard.Identity
{
  public interface ITokenService
  {
    Task<string> CreateToken(AppUser user);
  }
}