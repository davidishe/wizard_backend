using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SendpulseAPI;

namespace MyAppBack.Services.MailService
{
  public class MailService : IMailService
  {
    private readonly string _clientId;
    private readonly string _clientSecret;

    public MailService(IConfiguration config)
    {
      _clientId = config.GetSection("SendPulseSettings:client_id").Value;
      _clientSecret = config.GetSection("SendPulseSettings:client_secret").Value;
    }

    public void GetEmailsFromBook(int BookId)
    {
        throw new System.NotImplementedException();
    }

    public void SendMail(string from_name, string from_email, string name_to, string email_to, string html, string text, string subject)
    {
      throw new NotImplementedException();
    }

    public void SmtpSendMail(string from_name, string from_email, string name_to, string email_to, string html, string text, string subject)
    {
        Sendpulse sp = new Sendpulse(_clientId, _clientSecret);
        Dictionary<string, object> from = new Dictionary<string, object>();
        from.Add("name", from_name);
        from.Add("email", from_email);
        ArrayList to = new ArrayList();
        Dictionary<string, object> elementto = new Dictionary<string, object>();
        elementto.Add("name", name_to);
        elementto.Add("email", email_to);
        to.Add(elementto);
        Dictionary<string, object> emaildata = new Dictionary<string, object>();
        emaildata.Add("html", html);
        emaildata.Add("text", text);
        emaildata.Add("subject", subject);
        emaildata.Add("from", from);
        emaildata.Add("to", to);

        Dictionary<string, object> result = sp.SmtpSendMailAsync(emaildata).Result;
        Console.WriteLine("Response Status {0}", result["http_code"]);
        Console.WriteLine("Result {0}", result["data"]);
        Console.ReadKey();
    }

    public void SmtpSendMailWithAttachment(string from_name, string from_email, string name_to, string email_to, string html, string text, string subject, Dictionary<string, string> attachments)
    {
        throw new NotImplementedException();
    }
  }
}