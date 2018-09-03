using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class ScheduleWeekDays
    {
        public int Id_schedule { get; set; }
        public int Id_weekDays { get; set; }
        public DateTime Date { get; set; }

        public virtual Schedule Schedule { get; set; }
        public virtual WeekDays WeekDays { get; set; }
    }
}