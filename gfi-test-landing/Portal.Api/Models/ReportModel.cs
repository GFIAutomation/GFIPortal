using System;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Date_end { get; set; }
        public string Status { get; set; }
        public string General_message { get; set; }
        public string Error_message { get; set; }
        public string Warning_message { get; set; }
        public string Error_type { get; set; }
        public string Logs { get; set; }
        public int Id_batteryTest { get; set; }
        public int Id_machine { get; set; }
        public string Pass_tests { get; set; }
        public DateTime Duration { get; set; }
        public int Total_tests { get; set; }

        public virtual BatteryTest BatteryTest { get; set; }
        public virtual Machine Machine { get; set; }
    }
}