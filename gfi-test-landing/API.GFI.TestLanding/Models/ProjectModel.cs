using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace API.GFI.TestLanding
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo_url { get; set; }
        public byte[] ByteImage { get; set; }



        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<Battery> Battery { get; set; }     
        public virtual ICollection<BatteryTest> BatteryTest { get; set; }     
        public virtual ICollection<DisplayComponent> DisplayComponent { get; set; }      
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<Test> Test { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}