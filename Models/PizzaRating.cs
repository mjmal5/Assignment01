namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PizzaRating
    {
        public int Id { get; set; }
        public short Rating { get; set; }
        public string UserId { get; set; }
        public int PizzaId { get; set; }
    
        public virtual Pizza Pizza { get; set; }
    }
}
