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
    
    public partial class Subscribed_customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscribed_customers()
        {
            this.Customers_enter = new HashSet<Customers_enter>();
        }
    
        public int Subscription_id { get; set; }
        public int cust_id { get; set; }
        public int Subscription_type { get; set; }
        public System.DateTime start_date { get; set; }
        public int sum_of_entries { get; set; }
        public string status { get; set; }
    
        public virtual customers customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customers_enter> Customers_enter { get; set; }
        public virtual Subscription_type Subscription_type1 { get; set; }
    }
}
