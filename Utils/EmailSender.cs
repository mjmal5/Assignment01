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

namespace FIT5032_Assignment.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "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";

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

    public class BulkEmailSender
    {
        private const String API_KEY = "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";

        //private MariosPizzaModelContainer db = new MariosPizzaModelContainer();

        string Path = HttpContext.Current.Server.MapPath("\\Uploads\\Attachments\\");

        public void BulkSend(String subject, String contents, String attachment)
        {

            //int test = 0;
            //for (int i = 0; i < db.Customers.AsEnumerable().ToList().Count; i++)
            //{
            //    test = test + 1;
            //}



            //Create array of emails to loop through
            String ToEmail = "malcolm.malloy@gmail.com";

            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("news@mariospizza.com", "Career application");
            var to = new EmailAddress(ToEmail, "");
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