using System;
using System.Collections.Generic;
using Core.Identity;
using Core.Models;

namespace Core.Dtos
{
  public class OwnerLegalItemDto
  {

    public int Id { get; set; }
    public int ItemId { get; set; }
    public double ShareValue { get; set; }
    public string ShortName { get; set; }
    public string InnNumber { get; set; }
    public string OgrnNumber { get; set; }
    public string MainOkved { get; set; }
    public DateTime? RegDate { get; set; }
    public string LegalAddress { get; set; }

  };
}

