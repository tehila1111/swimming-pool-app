//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customers()
        {
            this.Rentals = new HashSet<Rentals>();
            this.Subscribed_customers = new HashSet<Subscribed_customers>();
        }
    
        public int cust_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
        public System.DateTime birthdate { get; set; }
        public string archive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rentals> Rentals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscribed_customers> Subscribed_customers { get; set; }
    }
}
