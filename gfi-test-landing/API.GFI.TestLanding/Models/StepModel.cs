using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class StepModel
    {
        public int Id_action { get; set; }
        public int Id_object { get; set; }
        public DateTime Last_update { get; set; }
        public string Status { get; set; }

        public virtual Action Action { get; set; }
        public virtual Object Object { get; set; }
    }
}