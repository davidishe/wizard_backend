using System;
using System.Collections.Generic;
using SendpulseAPI;

namespace MyAppBack.Services.MailService
{
    public interface IMailService
    {

        /// TODO: use this code
        /// <summary>
        /// Retrieving a list of emails from an address book
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="BookId"></param>
        void GetEmailsFromBook(int BookId);

        void SmtpSendMail(string from_name, string from_email, string name_to, string email_to, string html, string text, string subject);

        void SmtpSendMailWithAttachment(string from_name, string from_email, string name_to, string email_to, string html, string text, string subject, Dictionary<string, string> attachments);

        void SendMail(string from_name, string from_email, string name_to, string email_to, string html, string text, string subject);


    }
}