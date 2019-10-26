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

    //EMAIL SENDER
    public class EmailSender
    {
        private const String API_KEY = "INSERT API KEY";
        readonly string Path = HttpContext.Current.Server.MapPath("\\Uploads\\Attachments\\");

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

    //BULK EMAIL SENDER
    public class BulkEmailSender
    {
        private const String API_KEY = "INSERT API KEY";

        private MariosPizzaModelContainer db = new MariosPizzaModelContainer();

        string Path = HttpContext.Current.Server.MapPath("\\Uploads\\Attachments\\");

        public void BulkSend(String subject, String contents, String attachment)
        {
            var client = new SendGridClient(API_KEY);
            
            var from = new EmailAddress("news@mariospizza.com", subject);
            var to = new List<EmailAddress>();
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";

            //Get list of Emails from aspnetusers table 
            var emailList = new IdentityDbContext();
            var users = emailList.Users.ToList();


            //Populate to list
            for (int i = 0; i < users.Count; i++)
            {
                var CustomerEmail = users[i].Email;
                var CustomerName = users[i].UserName;
                to.Add(new EmailAddress(CustomerEmail, CustomerName));              
            }

            //Create message
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, htmlContent);

            //Attach file if applicable
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