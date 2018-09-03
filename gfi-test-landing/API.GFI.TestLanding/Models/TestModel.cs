using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creation_date { get; set; }
        public int Id_project { get; set; }
        public string Broswer { get; set; }

        public virtual ICollection<BatteryTest> BatteryTest { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<TestAction> TestAction { get; set; }
        public virtual ICollection<TestUser> TestUser { get; set; }
    }
}