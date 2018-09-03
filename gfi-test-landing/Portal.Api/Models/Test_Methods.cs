using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Test_Methods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Object> Object { get; set; }
    }
}