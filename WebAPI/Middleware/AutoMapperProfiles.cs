using AutoMapper;
using Core.Dtos;
using Core.Identity;
using Core.Models;

namespace WebAPI.Helpers
{
  public class AutoMapperProfiles : Profile
  {

    public AutoMapperProfiles()
    {
      CreateMap<HavenAppUser, UserToReturnDto>()
        .ForMember(d => d.PictureUrl, m => m.MapFrom(s => s.PictureUrl))
        .ForMember(d => d.UserPosition, m => m.MapFrom(s => s.UserPosition.Name))
        .ForMember(d => d.PictureUrl, m => m.MapFrom<UrlPictureForUserReslover>())
        .ForMember(d => d.BankOffice, m => m.MapFrom<UserBankOfficeResolver>())
        .ForMember(d => d.UserRoles, m => m.MapFrom<UserRolesReslover>());

      CreateMap<Item, ItemDto>()
        .ForMember(d => d.AppUser, m => m.MapFrom<UserResolver>())
        .ForMember(d => d.ItemType, m => m.MapFrom(s => s.ItemType.Name));


      CreateMap<OwnerLegalItem, OwnerLegalItemDto>()
        .ForMember(d => d.Id, m => m.MapFrom(s => s.OwnerLegal.Id))
        .ForMember(d => d.InnNumber, m => m.MapFrom(s => s.OwnerLegal.InnNumber))
        .ForMember(d => d.OgrnNumber, m => m.MapFrom(s => s.OwnerLegal.OgrnNumber))
        .ForMember(d => d.MainOkved, m => m.MapFrom(s => s.OwnerLegal.MainOkved))
        .ForMember(d => d.ShortName, m => m.MapFrom(s => s.OwnerLegal.ShortName))
        .ForMember(d => d.ShareValue, m => m.MapFrom(s => s.OwnerLegal.ShareValue))
        .ForMember(d => d.RegDate, m => m.MapFrom(s => s.OwnerLegal.RegDate))
        .ForMember(d => d.LegalAddress, m => m.MapFrom(s => s.OwnerLegal.LegalAddress));



      CreateMap<Member, MemberItemDto>()
        .ForMember(d => d.Name, m => m.MapFrom(s => s.Name))
        .ForMember(d => d.IsEnabled, m => m.MapFrom(s => s.IsEnabled));


      CreateMap<Core.Identity.Address, AddressDto>().ReverseMap();



    }



  }
}