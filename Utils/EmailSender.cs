using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_Assignment.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "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";
        //private const string Path = "C:\\Users\\Malcolm\\source\\repos\\FIT5032_Assignment\\Uploads\\Attachments\\file.txt";

        string Path = HttpContext.Current.Server.MapPath("\\Uploads\\Attachments\\");

        public void Send(String FromEmail, String subject, String contents, String attachment)
        {

            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress(FromEmail, "Career application");
            var to = new EmailAddress("malcolm.malloy@gmail.com", "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var bytes = File.ReadAllBytes(Path + attachment);
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(attachment, file);

            var response = client.SendEmailAsync(msg);
        }

    }
}