using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string Status { get; set; }
        public string Id_user { get; set; }
        public int Id_project { get; set; }
        public int Id_batteryTest { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual BatteryTest BatteryTest { get; set; }
        public virtual Project Project { get; set; }
    }
}