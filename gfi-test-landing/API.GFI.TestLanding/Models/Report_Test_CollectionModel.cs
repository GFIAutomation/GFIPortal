using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class Report_Test_CollectionModel
    {
        public int Id { get; set; }
        public DateTime? Date_start { get; set; }
        public DateTime? Date_end { get; set; }
        public string Status { get; set; }
        public string General_message { get; set; }
        public int? Report_test_id { get; set; }
        public int Report_id { get; set; }
    }
}