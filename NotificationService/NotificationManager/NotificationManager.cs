using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Models;
using Infrastructure.Data.Repos.GenericRepository;
using Infrastructure.Data.Spec;
using Infrastructure.Services.TelegramService;
using Microsoft.Extensions.Logging;

namespace NotificationService.Notification
{

  public class NotificationManager : INotificationManager
  {
    private readonly ITelegramService _telegramService;
    private readonly IGenericRepository<Item> _itemsRepo;
    private readonly IGenericRepository<Member> _membersRepo;
    private readonly ILogger<NotificationManager> _logger;


    public NotificationManager(
      ITelegramService telegrammService,
      ILogger<NotificationManager> logger,
      IGenericRepository<Item> itemRepo,
      IGenericRepository<Member> membersRepo

    )
    {
      _telegramService = telegrammService;
      _itemsRepo = itemRepo;
      _logger = logger;
      _membersRepo = membersRepo;
    }

    public Task ExecuteRegularJob(string jobId)
    {
      var items = _itemsRepo.ListAllAsync().Result;
      var item = items.Where(x => x.JobId == jobId).FirstOrDefault();
      var messageToSend = GetRegularMessageWithSpeakerAsync(item.MessageText).Result;
      _logger.LogInformation($"{DateTime.Now} было отправлено сообщение {messageToSend} в чат {item.ChatId}");

      DayOfWeek dayToday = DateTime.Now.DayOfWeek;
      if ((dayToday != DayOfWeek.Saturday) && (dayToday != DayOfWeek.Sunday))
        _telegramService.SendMessage(item.ChatId, messageToSend);

      return Task.CompletedTask;
    }


    public Task ExecuteHappyBirthdayJob(string jobId)
    {
      var items = _itemsRepo.ListAllAsync().Result;
      var item = items.Where(x => x.JobId == jobId).FirstOrDefault();
      var membersWithBirthday = GetMessageForBirthdayMembers().Result;

      foreach (var member in membersWithBirthday)
      {
        var messageToSend = GetRegularMessageWithSpeakerAsync(item.MessageText).Result;
        _logger.LogInformation($"{DateTime.Now} было отправлено сообщение {messageToSend} в чат {item.ChatId}");
        _telegramService.SendMessage(item.ChatId, messageToSend);

      }


      return Task.CompletedTask;
    }


    private async Task<Member[]> GetMessageForBirthdayMembers()
    {

      var spec = new MemberSpecification();
      var members = await _membersRepo.ListAsync(spec);
      var memberWithBirthday = members.Where(x => x.BirthdayDate.Date.Month == DateTime.Now.Date.Month && x.BirthdayDate.Date.Day == DateTime.Now.Date.Day);
      var membersArray = memberWithBirthday.ToArray();
      return membersArray;
    }


    private async Task<string> GetRegularMessageWithSpeakerAsync(string message)
    {

      var spec = new MemberSpecification();
      var members = await _membersRepo.ListAsync(spec);
      var membersArray = members.ToArray();
      var rnd = new Random();
      var rndIndex = rnd.Next(membersArray.Length);

      string output = message.Replace("{человек}", membersArray[rndIndex].Name);
      Console.WriteLine(output);
      return output;
    }







  }
}