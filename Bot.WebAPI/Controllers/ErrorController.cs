using Microsoft.AspNetCore.Mvc;
using Infrastructure.Errors;

namespace WebAPI.Controllers
{
  [Route("errors/{code}")]
  public class ErrorController : BaseApiController
  {
    public IActionResult Error(int code)
    {
      return new ObjectResult(new ApiResponse(code));
    }
  }
}