using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class AtributeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
        public virtual ICollection<Object> Object { get; set; }
    }
}