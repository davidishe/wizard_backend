using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebAPI.Controllers
{


  [ApiController]
  [Route("api")]
  public class BotController : ControllerBase
  {
    private readonly string _telegramToken;
    private readonly string _botName;

    public BotController(
      IConfiguration config
    )
    {
      _telegramToken = config.GetSection("BotSettings:TelegramToken").Value;
      _botName = config.GetSection("BotSettings:BotName").Value;
    }


    [AllowAnonymous]
    [HttpPost]
    [Route("message/update")]
    public async Task<IActionResult> Post([FromBody] Update update)
    {
      if (update == null) return Ok(404);
      var client = new TelegramBotClient(_telegramToken);

      var message = update.Message;
      if (message == null) return Ok(403);


      if (message.Text == null)
        return Ok("Пришло пустое сообщение");


      if (update.Message.Chat == null)
        return Ok("Нет идентификатора чата");

      var chatId = update.Message.Chat.Id;

      //TODO: логировать что пришло на хук


      if ((update.Type == Telegram.Bot.Types.Enums.UpdateType.Message) && message.Text.Contains(_botName))
      {
        await client.SendTextMessageAsync(chatId, $"ответ на сообщение '{message.Text}' в чате  c Id: {chatId}");
      }


      return Ok();
    }

  }
}




// https://api.telegram.org/bot1927355326:AAGtnIONVi30ts2sTemjIRWTSD5xWHvWQsE/setwebhook?url=https://4883-128-68-90-226.ngrok.io/api/message/update

// https://api.telegram.org/bot1932370800:AAH8kyNL9VYMWh-XcJJqcE_e88W56G1QCWM/setwebhook?url=https://bot.karabaradaram.ru/api/message/update