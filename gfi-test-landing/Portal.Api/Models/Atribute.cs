using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Atribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
        public virtual ICollection<Object> Object { get; set; }
    }
}