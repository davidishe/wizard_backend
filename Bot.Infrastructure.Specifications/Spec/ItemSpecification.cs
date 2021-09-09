using System;
using Core.Helpers;
using Core.Models;

namespace Bot.Infrastructure.Specifications
{
  public class ItemSpecification : BaseSpecification<Item>
  {
    public ItemSpecification(UserParams userParams)
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


    public ItemSpecification()
    : base()
    {
      AddInclude(x => x.ItemType);
    }



    public ItemSpecification(int id) : base(x => x.Id == id)
    {
      AddInclude(x => x.ItemType);
    }
  }


}