using System;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Storage;
using NotificationService.Notification;

namespace NotificationService.JobManagment
{

  public class JobManager : IJobManager
  {


    private readonly INotificationManager _notificationManager;

    public JobManager(
      INotificationManager notificationManager
    )
    {
      _notificationManager = notificationManager;
    }

    [Obsolete]
    public string AddRecurringJob(string cronExpression)
    {
      var timeZone = TimeZone.CurrentTimeZone;
      var jobId = Guid.NewGuid().ToString();
      RecurringJob.AddOrUpdate(jobId, () => _notificationManager.ExecuteRegularJob(jobId), cronExpression, TimeZoneInfo.Local);
      return jobId;
    }

    public bool UpdateRecurringJob(string jobId, string cronExpression)
    {
      RecurringJob.AddOrUpdate(jobId, () => _notificationManager.ExecuteRegularJob(jobId), cronExpression, TimeZoneInfo.Local);
      return true;
    }

    public bool DeleteRecurringJob(string jobId)
    {
      RecurringJob.RemoveIfExists(jobId);
      return true;
    }

    public string GetCronExpressionByJobId(string jobId)
    {
      var recurringJobs = JobStorage.Current.GetConnection().GetRecurringJobs();
      var job = recurringJobs.Where(x => x.Id == jobId).FirstOrDefault();
      if (job == null)
      {
        return "Значение не найдено";
      }
      var cronExpression = job.Cron;
      return cronExpression;
    }


  }
}