using System;
using Infrastructure.Helpers;
using Core.Models;

namespace Infrastructure.Data.Spec
{
  public class MemberSpecification : BaseSpecification<Member>
  {
    public MemberSpecification(UserParams userParams)
    : base(x =>
          (string.IsNullOrEmpty(userParams.Search) || x.Name.ToLower().Contains(userParams.Search.ToLower())))
    {
      AddInclude(x => x.MemberItems);

      ApplyPaging((userParams.PageSize * (userParams.PageIndex)), userParams.PageSize);

      if (!string.IsNullOrEmpty(userParams.sort))
      {
        switch (userParams.sort)
        {
          case "name":
            AddOrderByAscending(s => s.Name);
            break;
          default:
            AddOrderByAscending(x => x.IsEnabled);
            break;
        }
      }
    }


    public MemberSpecification()
    : base()
    {
      AddInclude(x => x.MemberItems);
    }



    public MemberSpecification(int id) : base(x => x.Id == id)
    {
      AddInclude(x => x.MemberItems);
    }
  }


}