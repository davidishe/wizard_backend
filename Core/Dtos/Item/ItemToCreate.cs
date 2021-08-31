using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
  public class ItemToCreateDto
  {

    public int? Id { get; set; }
    public string CompanyShortName { get; set; }
    public string CompanyFullName { get; set; }
    public string? ItemUrl { get; set; }
    public string? DirectorPosition { get; set; }
    public string? DirectorName { get; set; }
    public string? UserPosition { get; set; }
    public string? UserFamilyName { get; set; }
    public string? UserName { get; set; }
    public int? UserId { get; set; }
    public int ItemTypeId { get; set; }
    public string? Type { get; set; }
    public string? InnNumber { get; set; }
    public string? OgrnNumber { get; set; }
    public string? AccountNumberPsb { get; set; }
    public string? OfficeNamePsb { get; set; }
    public string? GosKontractIdentificator { get; set; }
    public string? GosKontractNumber { get; set; }
    public DateTime? GosKontractDate { get; set; }
    public string? GosKontractOwnerAccount { get; set; }


    [Required]
    public string CompanyLatinName { get; set; }
    public string ClientPhoneNumber { get; set; }
    public string WebSiteAddress { get; set; }
    public string LegalAddress { get; set; }
    public string FactAddress { get; set; }
    public string PostAddress { get; set; }

  }
}