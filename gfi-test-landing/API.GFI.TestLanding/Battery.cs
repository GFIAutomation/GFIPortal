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
    
    public partial class Battery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Battery()
        {
            this.BatteryTest = new HashSet<BatteryTest>();
            this.BatteryUser = new HashSet<BatteryUser>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<int> id_project { get; set; }
    
        public virtual Project Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatteryTest> BatteryTest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatteryUser> BatteryUser { get; set; }
    }
}
