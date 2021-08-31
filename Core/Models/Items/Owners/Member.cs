using System.Collections.Generic;

namespace Core.Models
{
  public class Member : BaseEntity
  {

    public string Name { get; set; }
    public bool IsEnabled { get; set; }
    public virtual ICollection<MemberItem>? MemberItems { get; set; }

  }
}