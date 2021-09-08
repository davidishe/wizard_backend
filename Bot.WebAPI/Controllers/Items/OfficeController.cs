using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data.Repos.GenericRepository;
using Infrastructure.Data.Spec;
using Core.Dtos;
using Infrastructure.Helpers;
using Core.Models;

namespace WebAPI.Controllers
{


  [AllowAnonymous]
  public class OfficeController : BaseController<Office>
  {

    public OfficeController(IGenericRepository<Office> context) : base(context)
    {
    }


  }
}