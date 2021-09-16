using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Core.Models;
using Wizard.Infrastructure.Database;

namespace Infrastructure.Database.SeedData
{
  public class DataContextSeed
  {

    public static async Task SeedDataAsync(DataContext context, ILoggerFactory loggerFactory)
    {
      try
      {

        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (!context.Links.Any())
        {
          var itemsData = File.ReadAllText(path + @"/Seed/SeedData/links.json");
          var items = JsonSerializer.Deserialize<List<Link>>(itemsData);
          foreach (var item in items)
          {
            context.Links.Add(item);
          }
          await context.SaveChangesAsync();
        }

      }
      catch (Exception ex)
      {
        var logger = loggerFactory.CreateLogger<DataContextSeed>();
        logger.LogError(ex.Message);
      }
    }


  }
}