using System;
using Infrastructure.Helpers;
using Core.Models;

namespace Infrastructure.Data.Spec
{
  public class DocForCountSpecification : BaseSpecification<Item>
  {
    public DocForCountSpecification(UserParams userParams)
          : base(x =>
          (string.IsNullOrEmpty(userParams.Search) || x.MessageText.ToLower().Contains(userParams.Search.ToLower())) &&
          (!userParams.typeId.HasValue || x.ItemTypeId == userParams.typeId)

        )
    {

    }

  }

}