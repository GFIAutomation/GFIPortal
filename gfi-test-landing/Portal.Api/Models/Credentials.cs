using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Credentials
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public DateTime date { get; set; }
    }
}