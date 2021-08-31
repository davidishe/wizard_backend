using System;
using Infrastructure.Helpers;
using Core.Models;

namespace Infrastructure.Data.Spec
{
  public class DocSpecification : BaseSpecification<Item>
  {
    public DocSpecification(UserParams userParams)
    : base(x =>
          (string.IsNullOrEmpty(userParams.Search) || x.MessageText.ToLower().Contains(userParams.Search.ToLower())) &&
          (!userParams.typeId.HasValue || x.ItemTypeId == userParams.typeId)
        )
    {
      AddInclude(x => x.ItemType);

      ApplyPaging((userParams.PageSize * (userParams.PageIndex)), userParams.PageSize);
      AddOrderByDescending(x => x.EnrolledDate);

      if (!string.IsNullOrEmpty(userParams.sort))
      {
        switch (userParams.sort)
        {
          case "name":
            AddOrderByAscending(s => s.MessageText);
            break;
          default:
            AddOrderByAscending(x => x.EnrolledDate);
            break;
        }
      }
    }


    public DocSpecification()
    : base()
    {
      AddInclude(x => x.ItemType);
    }



    public DocSpecification(int id) : base(x => x.Id == id)
    {
      AddInclude(x => x.ItemType);
    }
  }


}