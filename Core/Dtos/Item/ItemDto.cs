using System;
using System.Collections.Generic;
using Core.Identity;
using Core.Models;

namespace Core.Dtos
{
  public class ItemDto
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string MessageText { get; set; }
    public int? AuthorId { get; set; }
    public string? ChatId { get; set; }
    public string? JobId { get; set; }
    public UserToReturnDto? AppUser { get; set; }
    public string? ItemType { get; set; }
    public int? ItemTypeId { get; set; }
    public DateTime EnrolledDate { get; set; }
    public string CronExpression { get; set; }

  };
}

