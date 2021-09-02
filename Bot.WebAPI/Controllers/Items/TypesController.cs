using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data.Repos.GenericRepository;
using Infrastructure.Data.Spec;
using Core.Dtos;
using Infrastructure.Helpers;
using Core.Models;

namespace WebAPI.Controllers
{


  [AllowAnonymous]
  public class TypesController : BaseApiController
  {


    private readonly IGenericRepository<ItemType> _typesRepo;


    public TypesController(IGenericRepository<ItemType> typeRepo)
    {
      _typesRepo = typeRepo;
    }




    #region 2. Get regions & types functionality

    [AllowAnonymous]
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<IReadOnlyList<ItemType>>> GetProductRegionsByIdAsync()
    {
      var items = await _typesRepo.ListAllAsync();
      await SetTimeOut();
      return Ok(items);
    }


    [AllowAnonymous]
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<IReadOnlyList<ItemType>>> CreateProductRegionAsync(ItemType animalRegion)
    {
      var product = await _typesRepo.AddEntityAsync(animalRegion);
      await SetTimeOut();
      return Ok(product);
    }


    private async Task<bool> SetTimeOut()
    {
      await Task.Delay(10);
      return true;
    }

    #endregion

  }
}