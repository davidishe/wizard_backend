using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Identity;
using Infrastructure.Services;
using Bot.Identity.Services;

namespace WebAPI.Controllers
{


  [AllowAnonymous]
  public class PositionsController : BaseApiController
  {


    private readonly IUserPositionsService _repo;
    private readonly IMapper _mapper;


    public PositionsController(IUserPositionsService repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }


    [AllowAnonymous]
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<IReadOnlyList<UserPosition>>> GetItemsAsync()
    {
      var items = await _repo.GetAll();
      return Ok(items);
    }


    [AllowAnonymous]
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<IReadOnlyList<UserPosition>>> CreateItemAsync(UserPosition item)
    {
      var result = await _repo.AddEntityAsync(item);
      if (result == false)
        return BadRequest("Что-то пошло не так при обновлении значения");
      return Ok(200);
    }


  }
}