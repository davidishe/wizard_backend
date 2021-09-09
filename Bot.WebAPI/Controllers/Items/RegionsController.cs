using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Dtos;
using Infrastructure.Helpers;
using Core.Models;
using Bot.Infrastructure.Specifications;
using Infrastructure.Database;

namespace WebAPI.Controllers
{


  [AllowAnonymous]
  public class RegionsController : BaseApiController
  {


    private readonly IGenericRepository<Region> _itemRegionRepo;
    private readonly IMapper _mapper;


    public RegionsController(IGenericRepository<Region> productRegionRepo, IMapper mapper)
    {
      _itemRegionRepo = productRegionRepo;
      _mapper = mapper;
    }




    #region 2. Get regions & types functionality

    [AllowAnonymous]
    [HttpGet]
    [Route("regions")]
    public async Task<ActionResult<IReadOnlyList<Region>>> GetProductRegionsByIdAsync()
    {
      var spec = new BaseSpecification<Region>();
      var product = await _itemRegionRepo.ListAsync(spec);
      await SetTimeOut();
      return Ok(product);
    }


    [AllowAnonymous]
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<IReadOnlyList<ItemType>>> CreateProductRegionAsync(Region animalRegion)
    {
      var product = await _itemRegionRepo.AddEntityAsync(animalRegion);
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