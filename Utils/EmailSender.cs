using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FIT5032_Assignment.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "INSERT API KEY";

        string Path = HttpContext.Current.Server.MapPath("\\Uploads\\Attachments\\");

        public void Send(String FromEmail, String subject, String contents, String attachment)
        {

            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress(FromEmail, "Career application");
            var to = new EmailAddress("malcolm.malloy@gmail.com", "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            if (attachment != "")
            {
                var bytes = File.ReadAllBytes(Path + attachment);
                var file = Convert.ToBase64String(bytes);
                msg.AddAttachment(attachment, file);
            }


            var response = client.SendEmailAsync(msg);
        }

    }

    public class BulkEmailSender
    {
        private const String API_KEY = "INSERT API KEY";

        private MariosPizzaModelContainer db = new MariosPizzaModelContainer();

        string Path = HttpContext.Current.Server.MapPath("\\Uploads\\Attachments\\");

        public void BulkSend(String subject, String contents, String attachment)
        {

            var context = new IdentityDbContext();
            var users = context.Users.ToList();
            String ToEmail = "";

            for (int i = 0; i < users.Count; i++)
            {
                ToEmail = users[i].Email;

                var client = new SendGridClient(API_KEY);
                var from = new EmailAddress("news@mariospizza.com", "A message Mario's Pizza");
                var to = new EmailAddress(ToEmail, "");
                var plainTextContent = contents;
                var htmlContent = "<p>" + contents + "</p>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                if (attachment != "")
                {
                    var bytes = File.ReadAllBytes(Path + attachment);
                    var file = Convert.ToBase64String(bytes);
                    msg.AddAttachment(attachment, file);
                }

                var response = client.SendEmailAsync(msg);
            }





            
        }

    }
}