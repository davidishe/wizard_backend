using System;
using System.Threading.Tasks;

namespace NotificationService.Notification
{
  public interface INotificationManager
  {
    Task Execute(string jobId);

  }

}