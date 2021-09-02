using System;
using System.Collections.Generic;

namespace Core.Models
{
  public class Member : BaseEntity
  {
    public Member()
    {
    }

    public Member(string name, bool isEnabled, DateTime birthdayDate)
    {
      Name = name;
      IsEnabled = isEnabled;
      BirthdayDate = birthdayDate;

    }

    public string Name { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime BirthdayDate { get; set; }
    public virtual ICollection<MemberItem>? MemberItems { get; set; }

  }
}