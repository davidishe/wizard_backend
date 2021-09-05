using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Xunit;

namespace Bot.WebAPI.Tests
{
  public class MembersControllerUnitTests
  {

    private MembersController controller;

    public MembersControllerUnitTests()
    {
      controller = new MembersController();
    }

    [Fact]
    public void GetRegions_ReturnsOk()
    {

      var result = controller.GetRegionsAsync();
      Assert.IsAssignableFrom<Task<ActionResult<IReadOnlyList<ItemType>>>>(result);

    }
  }
}
