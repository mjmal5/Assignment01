namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        public int CustId { get; set; }

        [Display(Name = "First Name")]
        //[StringLength(40, MinimumLength = 8, ErrorMessage = "Maximum length is {1}")]
        [StringLength(40, ErrorMessage = "First Name must not exceed 40 characters.")]
        public string CustFirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(40, ErrorMessage = "Last Name must not exceed 40 characters.")]
        public string CustLastName { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(13, ErrorMessage = "Phone Number must not exceed 13 characters.")]
        public string CustPhoneNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string CustEmail { get; set; }
    }
}
