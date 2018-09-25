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
    
    public partial class BatteryTest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BatteryTest()
        {
            this.Report = new HashSet<Report>();
            this.Request = new HashSet<Request>();
            this.Build = new HashSet<Build>();
        }
    
        public int id { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<int> id_environment { get; set; }
        public Nullable<int> id_schedule { get; set; }
        public Nullable<int> id_project { get; set; }
        public Nullable<int> id_test { get; set; }
        public Nullable<int> id_battery { get; set; }
    
        public virtual Battery Battery { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual Project Project { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Test Test { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Report { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Request { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Build> Build { get; set; }
    }
}
