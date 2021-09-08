using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Identity;
using Core.Models;
using Infrastructure.Data.Repos.GenericRepository;
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
    private readonly IGenericRepository<ItemType> _itemTypeRepo;
    private readonly IGenericRepository<ItemSubType> _itemRegionRepo;
    private readonly IGenericRepository<BankOffice> _officeRepo;
    private readonly IMapper _mapper;
    private readonly UserManager<HavenAppUser> _userManager;


    public MembersControllerUnitTests()
    {
      _controller = new MembersController(
        _membersRepo,
        _itemTypeRepo,
        _itemRegionRepo,
        _officeRepo,
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
