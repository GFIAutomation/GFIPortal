using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding.Models
{
    public class ToolsStep
    {
        public int Id { get; set; }
        public int Id_tools_test { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Error_message { get; set; }
        public string Screenshot { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public DateTime Data_start { get; set; }
        public DateTime Data_end { get; set; }

        public virtual Tools_Test Tools_Test { get; set; }
    }
}