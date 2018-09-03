using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class TestAction
    {
        public int Id_Test { get; set; }
        public int Id_Action { get; set; }
        public DateTime Date { get; set; }
        public byte[] Printscreen { get; set; }

        public virtual Action Action { get; set; }
        public virtual Test Test { get; set; }
    }
}