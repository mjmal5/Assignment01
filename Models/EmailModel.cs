namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public class EmailModel : DbContext
    {

        public EmailModel()
            : base("name=EmailModel")
        {
        }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string FromEmail { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Name = "Cover Letter")]
        [Required(ErrorMessage = "Please enter your cover letter")]
        public string Contents { get; set; }

        //[Display(Name = "Attach your CV")]
        //public string Attachment { get; set; }

        [Display(Name = "Attach your CV")]
        public string Attachment { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }


    }


}