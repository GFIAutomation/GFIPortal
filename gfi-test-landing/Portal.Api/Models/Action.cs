using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ActionObject> ActionObject { get; set; }
        public virtual ICollection<Step> Step { get; set; }
        public virtual ICollection<TestAction> TestAction { get; set; }
    }
}