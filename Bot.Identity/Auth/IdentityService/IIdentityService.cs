using System.Threading.Tasks;
using Core.Domain;
using Core.Models.Contracts;

namespace Bot.Identity.Services
{
  public interface IIdentityService
  {

    Task<ExternalAuthResult> LoginWithFacebookAsync(string accessToken);
    Task<ExternalAuthResult> LoginWithGoogleAsync(string accessToken);


    Task<AccesssTokenResponse> GetFacebookAccessToken(string code);
    Task<AccesssTokenResponse> GetGoogleAccessToken(string code);

  }
}