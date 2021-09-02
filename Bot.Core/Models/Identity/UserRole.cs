using Microsoft.AspNetCore.Identity;
using Core.Identity;

namespace Core.Models.Identity
{
  public class UserRole : IdentityUserRole<int>
  {
    public virtual HavenAppUser User { get; set; }
    public virtual Role Role { get; set; }

  }
}