using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using Core.Identity;
using Core.Models.Contracts;

namespace Bot.Identity.Services
{
  public interface IUserPositionsService
  {

    Task<bool> ChangeItem(string[] roles, string userId);

    Task<bool> AddEntityAsync(UserPosition userPosition);

    Task<List<UserPosition>> GetAll();




  }
}