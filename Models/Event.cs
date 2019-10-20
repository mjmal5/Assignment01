namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Start { get; set; }
    }
}
