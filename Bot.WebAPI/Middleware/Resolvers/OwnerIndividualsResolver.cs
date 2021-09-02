using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Dtos;
using Core.Models;
using Infrastructure.Data.Contexts;


namespace WebAPI.Helpers
{

  public class MembersResolver : IValueResolver<Item, ItemDto, ICollection<Member>>
  {
    public MembersResolver()
    {
    }

    private readonly DataContext _context;
    // private readonly IMapper _mapper;


    public MembersResolver(
      DataContext context
    // IMapper mapper
    )
    {
      // _mapper = mapper;
      _context = context;
    }

    public ICollection<Member> Resolve(Item source, ItemDto destination, ICollection<Member> destMember, ResolutionContext context)
    {
      var owners = _context.Members.Where(x => x.Id == source.Id).ToList();
      return owners;
    }


  }

}