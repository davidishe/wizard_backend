using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace Bot.Services.Telegram.Extensions
{
  public static class TelegramBotExtension
  {
    public static IServiceCollection AddTelegramBotClient(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
      var client = new TelegramBotClient(configuration["BotSettings:TelegramToken"]);
      var webHook = $"{configuration["AppSettings:Url"]}/api/message/update";
      client.SetWebhookAsync(webHook).Wait();

      return serviceCollection
          .AddTransient<ITelegramBotClient>(x => client);
    }
  }
}