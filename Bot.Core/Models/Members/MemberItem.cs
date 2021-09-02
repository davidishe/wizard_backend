using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Core.Models
{
  public class MemberItem : BaseEntity
  {

    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int MemberId { get; set; }
    public Member Member { get; set; }

  }
}