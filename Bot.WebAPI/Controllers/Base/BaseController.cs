using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repos.GenericRepository;
using Infrastructure.Data.Spec;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
  {

    private IGenericRepository<TEntity> _repo { get; set; }

    public BaseController(IGenericRepository<TEntity> repo)
    {
      _repo = repo;
    }


    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<IReadOnlyList<TEntity>>> GetAllAsync()
    {
      await SetTimeOut();
      var spec = new BaseSpecification<TEntity>();
      var entitys = await _repo.ListAsync(spec);
      return Ok(entitys);
    }


    [HttpGet]
    [Route("getbyid")]
    public async Task<ActionResult<IReadOnlyList<TEntity>>> GetById([FromQuery] int id)
    {
      await SetTimeOut();
      var entity = await _repo.GetByIdAsync(id);
      return Ok(entity);
    }


    private async Task<bool> SetTimeOut()
    {
      await Task.Delay(10);
      return true;
    }


  }
}