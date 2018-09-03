using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class BatteryTest
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Update_date { get; set; }
        public int Id_environment { get; set; }
        public int Id_schedule { get; set; }
        public int Id_project { get; set; }
        public int Id_test { get; set; }
        public int Id_battery { get; set; }

        public virtual Battery Battery { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual Project Project { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Test Test { get; set; }

        public virtual ICollection<ReportModel> Report { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}