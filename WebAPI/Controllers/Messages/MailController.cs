using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyAppBack.Services.MailService;

namespace WebAPI.Controllers
{

  [AllowAnonymous]
  public class MailController : BaseApiController
  {
    private readonly IMailService _mailService;

    public MailController(IMailService mailService)
    {
      _mailService = mailService;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("feedback")]
    public ActionResult SendFeedbackMail()
    {

      var html = System.IO.File.ReadAllText(Path.Combine("assets", "mail", "index.txt"));

      try
      {
        _mailService.SmtpSendMail("Home app", "info@karabaradaram.ru", "Dear friend", "david.akobiya@gmail.com", html: html, "Text body", "Привет из будущего");
        return Ok("Сообщение отправлено на почту");
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }



  }
}