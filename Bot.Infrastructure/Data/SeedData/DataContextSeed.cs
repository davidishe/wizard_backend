using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Infrastructure.Data.Contexts;
using Core.Models;
using Infrastructure.Data.Repos.GenericRepository;

namespace Infrastructure.Data.SeedData
{
  public class DataContextSeed
  {

    public static async Task SeedDataAsync(DataContext context, ILoggerFactory loggerFactory)
    {
      try
      {

        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (!context.Regions.Any())
        {
          var itemsData = File.ReadAllText(path + @"/Data/SeedData/Source/regions.json");
          var items = JsonSerializer.Deserialize<List<Region>>(itemsData);
          foreach (var item in items)
          {
            context.Regions.Add(item);
          }
          await context.SaveChangesAsync();
        }


        if (!context.ItemTypes.Any())
        {
          var itemsData = File.ReadAllText(path + @"/Data/SeedData/Source/types.json");
          var items = JsonSerializer.Deserialize<List<ItemType>>(itemsData);
          foreach (var item in items)
          {
            context.ItemTypes.Add(item);
          }
          await context.SaveChangesAsync();
        }


        if (!context.BankOffices.Any())
        {
          var itemsData = File.ReadAllText(path + @"/Data/SeedData/Source/bankoffices.json");
          var items = JsonSerializer.Deserialize<List<BankOffice>>(itemsData);
          foreach (var item in items)
          {
            context.BankOffices.Add(item);
          }
          await context.SaveChangesAsync();
        }

        if (!context.Members.Any())
        {
          var itemsData = File.ReadAllText(path + @"/Data/SeedData/Source/members.json");
          var items = JsonSerializer.Deserialize<List<Member>>(itemsData);
          foreach (var item in items)
          {
            context.Members.Add(item);
          }
          await context.SaveChangesAsync();
        }


        if (!context.Items.Any())
        {
          var itemsData = File.ReadAllText(path + @"/Data/SeedData/Source/items.json");
          var items = JsonSerializer.Deserialize<List<Item>>(itemsData);


          foreach (var item in items)
          {
            context.Items.Add(item);
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