using System.Linq;
using Hangfire;
using Infrastructure.Errors;
using Infrastructure.Services.TelegramService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.JobManagment;
using NotificationService.Notification;

namespace NotificationService.Extensions
{
  public static class NotificationExtension
  {
    public static IServiceCollection AddNotificationExtension(this IServiceCollection services, IConfiguration _config)
    {
      services.AddHangfire(h =>
        h.UseSqlServerStorage(_config.GetConnectionString("DefaultConnection")));
      services.AddHangfireServer();

      services.AddScoped<ITelegramService, TelegramService>();
      services.AddScoped<INotificationManager, NotificationManager>();
      services.AddScoped<IJobManager, JobManager>();




      services.Configure<ApiBehaviorOptions>(options =>
      {
        options.InvalidModelStateResponseFactory = actionContext =>
        {
          var errors = actionContext.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .SelectMany(x => x.Value.Errors)
            .Select(x => x.ErrorMessage).ToArray();

          var errorResponse = new ApiValidationErrorResponse()
          {
            Errors = errors
          };

          return new BadRequestObjectResult(errorResponse);

        };

      });

      return services;

    }
  }
}





