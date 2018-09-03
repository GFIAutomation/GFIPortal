using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class Object_TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descritpion { get; set; }
        public string Status { get; set; }
        public int Id_method { get; set; }
        public int Id_attribute { get; set; }
        public int Id_data { get; set; }

        
        public virtual ICollection<ActionObject> ActionObject { get; set; }
        public virtual Attribute Attribute { get; set; }
        public virtual Data Data { get; set; }
        public virtual Method Method { get; set; }
        public virtual ICollection<Step> Step { get; set; }
    }
}