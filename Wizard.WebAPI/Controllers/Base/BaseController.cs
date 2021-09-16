using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wizard.Infrastructure.Database;

namespace WebAPI.Controllers
{

  [AllowAnonymous]
  [ApiController]
  [Route("api/[controller]")]
  public class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
  {

    private readonly IDbRepository<TEntity> _repo;
    private readonly ILogger<BaseController<TEntity>> _logger;

    public BaseController(IDbRepository<TEntity> repo, ILogger<BaseController<TEntity>> logger)
    {
      _repo = repo;
      _logger = logger;
    }


    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<List<TEntity>>> GetAllAsync()
    {
      await SetTimeOut();
      var entitys = await _repo.GetAll().ToListAsync();
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

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<IReadOnlyList<TEntity>>> Create(TEntity entity)
    {
      await SetTimeOut();
      if (entity == null)
        return BadRequest("Вы отправили пустой объект");

      var entityToReturn = _repo.AddAsync(entity as TEntity);
      return Ok(entityToReturn);
    }


    [HttpPut]
    [Route("update")]
    public async Task<ActionResult<IReadOnlyList<TEntity>>> Update(TEntity entity)
    {
      await SetTimeOut();
      if (entity == null)
        return BadRequest("Вы отправили нам пустой объект");

      if (!(entity.Id >= 1))
        return BadRequest("У объекта должен быть id");

      await _repo.UpdateAsync(entity);
      _logger.LogInformation("значение было обновлено через update");
      return Ok(entity);
    }


    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult<IReadOnlyList<TEntity>>> Delete([FromQuery] int id)
    {
      await SetTimeOut();
      var entity = await _repo.GetByIdAsync(id);
      await _repo.DeleteAsync(entity);
      return Ok(entity);
    }


    private async Task<bool> SetTimeOut()
    {
      await Task.Delay(10);
      return true;
    }


  }
}