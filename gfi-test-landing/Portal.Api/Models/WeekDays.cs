using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class WeekDays
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ScheduleWeekDays> ScheduleWeekDays { get; set; }
    }
}