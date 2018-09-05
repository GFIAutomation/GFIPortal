using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfi_test_landing.Models
{
    public class Chart
    {
        public string Chrome { get; set; }
        public string Firefox { get; set; }
        public string IE { get; set; }
        public string Opera { get; set; }
        public string Safari { get; set; }
        public string Edge { get; set; }
        public string PassedTests { get; set; }
        public string FailedTests { get; set; }
        public List<int?> LastFiveBuildsTotal { get; set; }
        public List<int?> LastFiveBuildsPass { get; set; }
        public List<long?> LastFiveBuildsFail { get; set; }
        public List<String> DateList { get; set; }
        public string test { get; set; }
    }
    
    public class LastBatteryTests
    {
        
    }
}