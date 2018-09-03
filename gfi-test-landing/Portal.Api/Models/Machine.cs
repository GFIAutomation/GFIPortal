using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Cpu { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public string Date_created { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ReportModel> Report { get; set; }
    }
}