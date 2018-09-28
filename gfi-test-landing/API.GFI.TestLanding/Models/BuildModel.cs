using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class BuildModel
    {
        public int Id { get; set; }
        public int Id_project { get; set; }
        public string Tool_name { get; set; }
        public DateTime? Date_start { get; set; }
        public DateTime? Date_end { get; set; }
        public string Status { get; set; }
        public string General_message { get; set; }
        public int? Id_batteryTest { get; set; }
        public int? Id_machine { get; set; }
        public int? Pass_tests { get; set; }
        public string Duration { get; set; }
        public int? Total_tests { get; set; }
        public int? Failed_tests { get; set; }
        public int? Skipped_tests { get; set; }
        public string Username { get; set; }

        public virtual BatteryTest BatteryTest { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual Project Project { get; set; }
     
        public virtual ICollection<Tools_Test> Tools_Test { get; set; }
    }
}