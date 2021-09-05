using System.Collections.Generic;

namespace Infrastructure.Errors
{
  public class ApiValidationErrorResponse : ApiResponse
  {
    public ApiValidationErrorResponse() : base(400)
    {

    }

    public IList<string> Errors { get; set; }
  }
}