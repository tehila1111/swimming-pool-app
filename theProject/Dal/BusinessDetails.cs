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
    
    public partial class BusinessDetails
    {
        public string BusinessName { get; set; }
        public string address { get; set; }
        public string rentDay { get; set; }
        public int rentPrice { get; set; }
        public System.TimeSpan RentStartHour { get; set; }
        public System.TimeSpan RentEndHour { get; set; }
    }
}