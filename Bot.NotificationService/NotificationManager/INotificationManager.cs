using System;
using System.Threading.Tasks;

namespace NotificationService.Notification
{
  public interface INotificationManager
  {
    Task ExecuteRegularJob(string jobId);
    Task ExecuteHappyBirthdayJob(string jobId);



  }

}