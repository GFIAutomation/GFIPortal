using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Environment
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BatteryTest> BatteryTest { get; set; }
    }
}