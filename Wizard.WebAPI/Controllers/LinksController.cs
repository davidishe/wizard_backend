using Core.Models;
using Infrastructure.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WebAPI.Controllers;
using Wizard.Infrastructure.Database;

namespace Wizard.WebAPI.Controllers
{

  public class LinksController : BaseController<Link>
  {

    // public LinksController(
    //   DbRepository<Link> context,
    //   ILogger<LinksController> logger
    // ) : base(context, logger)
    // {
    // }
    public LinksController(IDbRepository<Link> repo, ILogger<BaseController<Link>> logger) : base(repo, logger)
    {
    }
  }
}