namespace FIT5032_Assignment.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public class BulkEmailModel : DbContext
    {

        public BulkEmailModel()
            : base("name=BulkEmailModel")
        {
        }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Name = "Email Body")]
        [Required(ErrorMessage = "Please enter your cover letter")]
        public string Contents { get; set; }

        [Display(Name = "Attachment")]
        public string Attachment { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }

}