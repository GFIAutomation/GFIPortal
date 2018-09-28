using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding.Models
{
    public class ToolsTest
    {
        public int Id { get; set; }
        public int Id_build { get; set; }
        public int Id_project { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? Date_start { get; set; }
        public DateTime? Date_end { get; set; }
        public string Duration { get; set; }
        public string Browser { get; set; }
        public string Site { get; set; }
        public string General_message { get; set; }
        public string Description { get; set; }
        public string Error_message { get; set; }

        public virtual Build Build { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Tools_Step> Tools_Step { get; set; }
    }
}