using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Core.Models
{
  public class OwnerLegal : BaseEntity
  {

    public double ShareValue { get; set; }
    public string ShortName { get; set; }
    public string InnNumber { get; set; }
    public string OgrnNumber { get; set; }
    public string MainOkved { get; set; }
    public DateTime? RegDate { get; set; }
    public string LegalAddress { get; set; }
    public virtual ICollection<OwnerLegalItem>? OwnerLegalItems { get; set; }


    // [JsonIgnore]
    // public Item Item { get; set; }


    // public int? ItemId { get; set; }
  }
}