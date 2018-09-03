using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Date_end { get; set; }
        public DateTime Date_start { get; set; }
        public TimeSpan Hour { get; set; }
        
        public virtual ICollection<BatteryTest> BatteryTest { get; set; }
        public virtual ICollection<ScheduleWeekDays> ScheduleWeekDays { get; set; }
    }
}