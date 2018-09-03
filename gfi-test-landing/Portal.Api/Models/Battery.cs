using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Battery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id_project { get; set; }
        public virtual Project Project { get; set; }
        
        public virtual ICollection<BatteryTest> BatteryTest { get; set; }
        public virtual ICollection<BatteryUser> BatteryUser { get; set; }
    }
}