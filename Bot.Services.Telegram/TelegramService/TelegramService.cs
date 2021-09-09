using System.Net;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.TelegramService
{
  public class TelegramService : ITelegramService
  {

    private readonly string _telegramToken;

    public TelegramService(
      IConfiguration config
    )
    {
      _telegramToken = config.GetSection("BotSettings:TelegramToken").Value;
    }


    public string SendMessage(string destID, string message)
    {
      string urlString = $"https://api.telegram.org/bot{_telegramToken}/sendMessage?chat_id={destID}&text={message}";
      WebClient webclient = new WebClient();
      var result = webclient.DownloadString(urlString);
      return result;
    }



  }
}