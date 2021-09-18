using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Core.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Identity
{
  public class AppUser : IdentityUser<int>
  {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }
    public string DisplayName { get; set; }
    public string? PictureUrl { get; set; }
    public string? UserDescription { get; set; }
    public virtual Address? Address { get; set; }

    public int BankOfficeId { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }

  }
}