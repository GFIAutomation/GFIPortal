//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Api
{
    using System;
    using System.Collections.Generic;
    
    public partial class Object
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Object()
        {
            this.ActionObject = new HashSet<ActionObject>();
            this.Step = new HashSet<Step>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string descritpion { get; set; }
        public string status { get; set; }
        public Nullable<int> id_method { get; set; }
        public Nullable<int> id_attribute { get; set; }
        public Nullable<int> id_data { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActionObject> ActionObject { get; set; }
        public virtual Attribute Attribute { get; set; }
        public virtual Data Data { get; set; }
        public virtual Method Method { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Step> Step { get; set; }
    }
}
