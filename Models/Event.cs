namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Event Title must not exceed 40 characters.")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Start { get; set; }
    }
}
