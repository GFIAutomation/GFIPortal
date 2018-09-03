using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class DisplayComponentModel
    {
        public int Id_component { get; set; }
        public int Id_project { get; set; }
        public bool Visible { get; set; }

        public virtual Component Component { get; set; }
        public virtual Project Project { get; set; }
    }
}