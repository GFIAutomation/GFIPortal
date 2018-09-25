using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace gfi_test_landing.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public string Logo_url { get; set; }
        public HttpPostedFileBase Image { get; set; }
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