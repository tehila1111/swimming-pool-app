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
    
    public partial class otherEnter
    {
        public int other_enter { get; set; }
        public System.DateTime date { get; set; }
        public int work_shift_id { get; set; }
    
        public virtual work_shift_type work_shift_type { get; set; }
    }
}