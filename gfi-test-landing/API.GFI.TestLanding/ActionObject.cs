//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.GFI.TestLanding
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActionObject
    {
        public int id_action { get; set; }
        public int id_object { get; set; }
        public Nullable<System.DateTime> last_update { get; set; }
        public string status { get; set; }
    
        public virtual Action Action { get; set; }
        public virtual Object Object { get; set; }
    }
}
