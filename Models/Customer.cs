namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        public int CustId { get; set; }

        [Display(Name = "First Name")]
        public string CustFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string CustLastName { get; set; }

        [Display(Name = "Phone Number")]
        public string CustPhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string CustEmail { get; set; }
    }
}
