namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Pizza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pizza()
        {
            this.PizzaRatings = new HashSet<PizzaRating>();
        }
    
        public int Id { get; set; }

        [StringLength(40, ErrorMessage = "Pizza Name must not exceed 40 characters.")]
        public string Name { get; set; }

        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PizzaRating> PizzaRatings { get; set; }
    }
}
