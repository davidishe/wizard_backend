using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Infrastructure.Helpers;
using Core.Identity;
using Core.Models;
using Infrastructure.Data.Repos.GenericRepository;
using Infrastructure.Data.Spec;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using Core.Extensions;
using NotificationService.JobManagment;
using NotificationService.Notification;
using Bot.Core.Validators;
using Infrastructure.Errors;

namespace WebAPI.Controllers
{


  [AllowAnonymous]
  public class MembersController : BaseApiController
  {

    private readonly IGenericRepository<Member> _membersRepo;
    private readonly IGenericRepository<ItemType> _itemTypeRepo;
    private readonly IGenericRepository<ItemSubType> _itemRegionRepo;
    private readonly IGenericRepository<BankOffice> _officeRepo;
    private readonly IMapper _mapper;
    private readonly UserManager<HavenAppUser> _userManager;


    public MembersController(
      IGenericRepository<Member> membersRepo,
      IGenericRepository<ItemType> productTypeRepo,
      IGenericRepository<ItemSubType> productRegionRepo,
      IGenericRepository<BankOffice> officeRepo,
      IMapper mapper,
      UserManager<HavenAppUser> userManager
    )
    {
      _membersRepo = membersRepo;
      _itemTypeRepo = productTypeRepo;
      _itemRegionRepo = productRegionRepo;
      _mapper = mapper;
      _officeRepo = officeRepo;
      _userManager = userManager;
    }

    // public MembersController()
    // {
    // }


    #region 1. Get products functionality


    [AllowAnonymous]
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<IReadOnlyList<MemberDto>>> GetAllMembers()
    {

      var spec = new MemberSpecification();
      var items = await _membersRepo.ListAsync(spec);

      var data = _mapper.Map<IReadOnlyList<Member>, IReadOnlyList<MemberDto>>(items);
      await SetTimeOut();
      return Ok(data);
    }


    [AllowAnonymous]
    [HttpGet("{id}")]
    [Route("getbyid")]
    public async Task<ActionResult<MemberDto>> GetByIdAsync([FromQuery] int id)
    {
      var spec = new MemberSpecification(id);
      var item = await _membersRepo.GetEntityWithSpec(spec);
      await SetTimeOut();

      var resultDto = _mapper.Map<Member, MemberDto>(item);
      return resultDto;

    }


    #endregion

    #region 2. Get regions & types functionality
    [AllowAnonymous]
    [HttpGet]
    [Route("types")]
    public async Task<ActionResult<IReadOnlyList<ItemType>>> GetProductTypesByIdAsync()
    {
      var product = await _itemTypeRepo.ListAllAsync();
      await SetTimeOut();
      return Ok(product);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("regions")]
    public async Task<ActionResult<List<Region>>> GetRegionsAsync()
    {
      Region[] items = new Region[] { new Region { Name = "Вологда" }, new Region { Name = "Калуга" }, new Region { Name = "Пенза" } };
      return Ok(items);
    }
    #endregion

    #region 3. Products CRUD functionality
    /*
    create, delete, update products
    */


    [AllowAnonymous]
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<Member>> Create(MemberDto itemDto)
    {

      var user = await _userManager.FindByClaimsCurrentUser(HttpContext.User);
      await SetTimeOut();

      MemberValidator validator = new MemberValidator();
      var validationResults = validator.Validate(itemDto);

      //TODO: реализовать возврат ошибок в виде error response object
      if (validationResults.IsValid == false)
      {
        foreach (var errorResult in validationResults.Errors)
        {
          return Ok($"{errorResult.PropertyName}: {errorResult.ErrorMessage}");
        }
      }


      var item = new Member
      (
        name: itemDto.Name,
        isEnabled: true,
        birthdayDate: new DateTime()
      // TODO: get id from user object
      // authorId: 2,
      );

      var itemToReturn = await _membersRepo.AddEntityAsync(item);
      return Ok(itemToReturn);

    }


    [AllowAnonymous]
    [HttpPut]
    [Route("update")]
    public async Task<ActionResult<Member>> UpdateProduct(MemberDto itemForUpdate)
    {

      var currentItem = _membersRepo.GetByIdAsync((int)itemForUpdate.Id).Result;

      if (currentItem == null)
        return BadRequest("Не найден объект для обновления");

      currentItem.IsEnabled = itemForUpdate.IsEnabled;
      currentItem.Name = itemForUpdate.Name;
      await SetTimeOut();

      var updatedItem = _membersRepo.Update(currentItem);
      if (updatedItem != null)
        return Ok(_mapper.Map<Member, MemberDto>(updatedItem));
      else
        return NotFound();

    }




    [AllowAnonymous]
    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult> DeleteProduct([FromQuery] int id)
    {

      await SetTimeOut();
      var item = await _membersRepo.GetByIdAsync(id);
      if (item != null)
      {
        _membersRepo.Delete(item);
        return Ok(202);
      }

      return BadRequest();

    }

    #endregion


    #region 5. Private methods for service functionaluty

    private async Task<bool> SetTimeOut()
    {
      await Task.Delay(100);
      return true;
    }

    #endregion

  }
}