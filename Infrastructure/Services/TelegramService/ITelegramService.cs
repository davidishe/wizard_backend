using System.Threading.Tasks;
using Core.Dtos;
using Core.Models;

namespace Infrastructure.Services.TelegramService
{
  public interface ITelegramService
  {
    string SendMessage(string destID, string message);

  }
}