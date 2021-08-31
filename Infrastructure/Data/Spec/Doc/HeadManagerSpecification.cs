using System;
using Infrastructure.Helpers;
using Core.Models;

namespace Infrastructure.Data.Spec
{
  public class HeadManagerSpecification : BaseSpecification<HeadManager
  >
  {

    public HeadManagerSpecification()
    : base()
    {
      AddInclude(x => x.Member);
      AddInclude(x => x.HeadManagerPosition);
    }



    public HeadManagerSpecification(int id) : base(x => x.Id == id)
    {
      AddInclude(x => x.Member);
      AddInclude(x => x.HeadManagerPosition);
    }
  }


}