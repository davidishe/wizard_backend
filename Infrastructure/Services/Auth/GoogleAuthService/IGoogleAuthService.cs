using System.Threading.Tasks;
using Core.External.Contracts;
using Core.Models.Contracts;
using Core.Models.Contracts.Google;

namespace Infrastructure.Services
{
  public interface IGoogleAuthService
  {
    Task<GoogleTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
    Task<GoogleUserInfoResult> GetUserInfoAsync(string accessToken);
    Task<AccesssTokenResponse> GetAccessTokenAsync(string code);

  }
}