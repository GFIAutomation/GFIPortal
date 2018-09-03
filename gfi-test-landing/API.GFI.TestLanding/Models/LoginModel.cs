using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class LoginModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Id_role { get; set; }
        public int Id_project { get; set; }
        public int Id_credentials { get; set; }
    }
}