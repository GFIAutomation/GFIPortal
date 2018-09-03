using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class UserRoleModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public int Id_project { get; set; }
        public DateTime Date { get; set; }

        public virtual AspNetRoles AspNetRoles { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Project Project { get; set; }
    }
}