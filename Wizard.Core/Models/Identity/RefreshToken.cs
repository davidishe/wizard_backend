using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Core.Identity;

namespace Core.Domain
{
  public class RefreshToken
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Token { get; set; }

    public string JwtId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public bool Used { get; set; }

    public bool Invalidated { get; set; }

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public AppUser User { get; set; }
  }
}