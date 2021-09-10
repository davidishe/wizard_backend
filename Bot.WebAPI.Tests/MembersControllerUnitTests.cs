using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Identity;
using Core.Models;
using FakeItEasy;
using Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Xunit;

namespace Bot.WebAPI.Tests
{
  public class MembersControllerUnitTests
  {

    private readonly MembersController _controller;
    private readonly IGenericRepository<Member> _membersRepo;
    private readonly IMapper _mapper;
    private readonly UserManager<HavenAppUser> _userManager;



    public MembersControllerUnitTests()
    {
      _controller = new MembersController(
        _membersRepo,
        _mapper,
        _userManager
      );
    }

    [Fact]
    public void GetAllMembers_ReturnsOk()
    {

      var result = _controller.GetAllMembers();
      Assert.IsAssignableFrom<Task<ActionResult<IReadOnlyList<MemberDto>>>>(result);

    }




  }
}
