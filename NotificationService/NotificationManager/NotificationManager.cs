using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Data.Repos.GenericRepository;
using Infrastructure.Services.TelegramService;
using Microsoft.Extensions.Logging;

namespace NotificationService.Notification
{

  public class NotificationManager : INotificationManager
  {
    private readonly ITelegramService _telegramService;
    private readonly IGenericRepository<Item> _itemRepo;
    private readonly ILogger<NotificationManager> _logger;


    public NotificationManager(
      ITelegramService telegrammService,
      ILogger<NotificationManager> logger,
      IGenericRepository<Item> itemRepo
    )
    {
      _telegramService = telegrammService;
      _itemRepo = itemRepo;
      _logger = logger;
    }

    public Task Execute(string jobId)
    {
      var items = _itemRepo.ListAllAsync().Result;
      var item = items.Where(x => x.JobId == jobId).FirstOrDefault();
      var messageToSend = GetRegularMessageWithSpeaker(item.MessageText);
      _logger.LogInformation($"{DateTime.Now} было отправлено сообщение {messageToSend} в чат {item.ChatId}");

      DayOfWeek dayToday = DateTime.Now.DayOfWeek;
      if ((dayToday != DayOfWeek.Saturday) && (dayToday != DayOfWeek.Sunday))
        _telegramService.SendMessage(item.ChatId, messageToSend);

      return Task.CompletedTask;
    }



    private string GetRegularMessageWithSpeaker(string message)
    {
      string[] members = new string[] { "Валерия Новицкая", "Артем Сергиенко", "Давид Акобия" };
      var rnd = new Random();
      var rndIndex = rnd.Next(members.Length);

      string output = message.Replace("{человек}", members[rndIndex]);
      Console.WriteLine(output);

      // TODO: ходить в базу и забирать список сотрудников
      // TODO: выбирать случайного и подставлять в регекс
      return output;
    }







  }
}