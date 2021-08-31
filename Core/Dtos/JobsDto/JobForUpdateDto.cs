using System;
using System.Threading.Tasks;

namespace Core.Dtos
{

  public class JobForUpdateDto
  {
    public string JobId { get; set; }
    public string CronExpression { get; set; }

  }
}