namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Booking
    {
        public int BookingId { get; set; }

        [Display(Name = "No. of Guests")]
        public byte BookingGuestNum { get; set; }


        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime BookingDate { get; set; }

        [Display(Name = "Time")]
        //Stringlength not required due to dropdown list (causes false positives)
        public string BookingTime { get; set; }

        [Display(Name = "Location")]
        public int LocationId { get; set; }

        public string UserId { get; set; }

        public virtual Location Location { get; set; }
    }
}