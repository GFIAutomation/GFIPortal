using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gfi_test_landing.Models
{
    public class AddUserToProjectViewModel
    {
        public string IdUser { get; set; }
        public int? IdProject { get; set; }
        public int DropIdProject { get; set; }
        public string DropIdUser { get; set; }
        public string DropIdRole { get; set; }
        public List<SelectListItem> dropListProject {get; set;}
        public List<SelectListItem> dropListUser { get; set; }

    }
}