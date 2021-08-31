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
  public class OfficeController : BaseApiController
  {


    private readonly IGenericRepository<BankOffice> _officeRepo;
    private readonly IMapper _mapper;


    public OfficeController(IGenericRepository<BankOffice> repo, IMapper mapper)
    {
      _officeRepo = repo;
      _mapper = mapper;
    }


    [AllowAnonymous]
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<IReadOnlyList<BankOffice>>> GetItemsAsync()
    {
      var items = await _officeRepo.ListAllAsync();
      return Ok(items);
    }


    [AllowAnonymous]
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<IReadOnlyList<BankOffice>>> CreateItemAsync(BankOffice item)
    {
      var product = await _officeRepo.AddEntityAsync(item);
      return Ok(product);
    }




  }
}