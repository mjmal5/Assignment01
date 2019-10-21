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
        private MariosPizzaModelContainer db = new MariosPizzaModelContainer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View(db.Pizzas.ToList());
        }

        public ActionResult StaffCalendar()
        {
            return View(db.Events.ToList());
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Finder()
        {
            return View(db.Locations.ToList());
        }

        public ActionResult PizzaRatings()
        {
            return View();
        }

        [HttpGet]
        public JsonResult RatingData()
        {

            List<PizzaRating> Data = db.PizzaRatings.ToList();

            var RatingData = Data.Select(S => new {
                Rating = S.Rating,
                PizzaId = S.PizzaId
            });

            //return list as Json
            return Json(RatingData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult NameData()
        {

            List<Pizza> Data = db.Pizzas.ToList();

            var NameData = Data.Select(S => new {
                Id = S.Id,
                Name = S.Name
            });

            //return list as Json
            return Json(NameData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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
                    string saveName = (name + "-" + $@"{DateTime.Now.Ticks}" + strExt);

                    if (attachment != null)
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        if ((strExt != ".pdf" && strExt != ".txt"))
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

        public ActionResult BulkEmail()
        {
            return View(new BulkEmailModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkEmail(BulkEmailModel model, HttpPostedFileBase attachment)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    String name = model.Name;
                    String contents = model.Contents;
                    //String attachment = model.Attachment;
                    //String fileAttachment = attachment.FileName;


                    string path = Server.MapPath("~/Uploads/Attachments/");
                    string strExt = Path.GetExtension(attachment.FileName);
                    string saveName = (name + "-" + $@"{DateTime.Now.Ticks}" + strExt);

                    if (attachment != null)
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        if ((strExt != ".pdf" && strExt != ".txt"))
                        {
                            ViewBag.Message = "Invalid File Type (Must be .pdf)";
                        }
                        else
                        {
                            attachment.SaveAs(path + Path.GetFileName(saveName));
                            ViewBag.Message = "File uploaded successfully.";
                        }
                    }


                    BulkEmailSender es = new BulkEmailSender();
                    es.BulkSend(name, contents, saveName);

                    ViewBag.Result = "Email has been sent";

                    ModelState.Clear();

                    return View(new BulkEmailModel());
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





