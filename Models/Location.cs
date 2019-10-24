namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
