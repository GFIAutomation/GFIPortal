using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Api.Models
{
    public class Login
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int Id_role { get; set; }
        public int Id_project { get; set; }
        public int Id_credentials { get; set; }
    }
}