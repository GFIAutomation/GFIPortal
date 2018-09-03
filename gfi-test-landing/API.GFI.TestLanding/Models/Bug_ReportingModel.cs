using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class Bug_ReportingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Current_behaviour { get; set; }
        public string Expected_behaviour { get; set; }
        public int Bug_reporting_collection_id { get; set; }
        public string Browser { get; set; }
        public string Operating_system { get; set; }
        public DateTime Date { get; set; }
    }
}