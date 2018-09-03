using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class BatteryUser
    {
        public string Id_user { get; set; }
        public int Id_battery { get; set; }
        public DateTime Creation_date { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Battery Battery { get; set; }
    }
}