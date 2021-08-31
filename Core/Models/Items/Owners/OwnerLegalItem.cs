using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Core.Models
{
  public class OwnerLegalItem : BaseEntity
  {

    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int OwnerLegalId { get; set; }
    public OwnerLegal OwnerLegal { get; set; }

  }
}