using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using FIT5032_Assignment.Models;
using FIT5032_Assignment.Utils;
using System.IO;

namespace FIT5032_Assignment.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Careers()
        {
            return View(new EmailModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Careers(EmailModel model, HttpPostedFileBase attachment)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.FromEmail;
                    String name = model.Name;
                    String contents = model.Contents;
                    //String attachment = model.Attachment;
                    //String fileAttachment = attachment.FileName;


                    string path = Server.MapPath("~/Uploads/Attachments/");
                    string strExt = Path.GetExtension(attachment.FileName);
                    string saveName = (name + "-" + $@"{DateTime.Now.Ticks}.txt");

                    if (attachment != null)
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        if ((strExt != ".pdf"))
                        {
                            ViewBag.Message = "Invalid File Type (Must be .pdf)";
                        }
                        else
                        {
                            attachment.SaveAs(path + Path.GetFileName(saveName));
                            ViewBag.Message = "File uploaded successfully.";
                        }
                    }


                    EmailSender es = new EmailSender();
                    es.Send(toEmail, name, contents, saveName);

                    ViewBag.Result = "Email has been sent";

                    ModelState.Clear();

                    return View(new EmailModel());
                }
                catch
                {
                    ViewBag.Result = "Email Failed!";
                    return View();
                }
            }

            return View();
        }
    }
}





