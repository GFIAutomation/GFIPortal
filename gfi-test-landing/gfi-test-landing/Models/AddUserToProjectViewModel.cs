using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gfi_test_landing.Models
{
    public class AddUserToProjectViewModel
    {
        public string IdUser { get; set; }
        public int? IdProject { get; set; }

        [Required]
        public int DropIdProject { get; set; }

       [Required]
        public string DropIdUser { get; set; }

        [Required]
        public string DropIdRole { get; set; }
        public List<SelectListItem> dropListProject {get; set;}
        public List<SelectListItem> dropListUser { get; set; }

    }
}