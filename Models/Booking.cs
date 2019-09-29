//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Booking
    {
        public int BookingId { get; set; }

        [Display(Name = "No. of Guests")]
        public int BookingGuestNum { get; set; }

        [Display(Name = "Date")]
        public System.DateTime BookingDate { get; set; }

        [Display(Name = "Time")]
        public System.TimeSpan BookingTime { get; set; }
        public int RestarauntRestId { get; set; }
        public int CustomerCustId { get; set; }
    
        public virtual Restaraunt Restaraunt { get; set; }
        public virtual Customer Customer { get; set; }
    }
}