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
  public class BaseApiController : ControllerBase
  {


  }
}