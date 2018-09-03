using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class WeekDaysModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ScheduleWeekDays> ScheduleWeekDays { get; set; }
    }
}