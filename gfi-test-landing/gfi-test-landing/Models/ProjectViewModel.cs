using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gfi_test_landing.Models
{
    public class ProjectViewModel
    {
        [Required]
        [Display(Name = "Project Description")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string ProjectDescription { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string ProjectName { get; set; }

        public string UrlImage { get; set; }

        public int Id { get; set; }

       public List<Components> Components { get; set; }
    }


    public class Components
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "IsSelected")]
        public bool IsSelected { get; set; }

    }

    public class UserRoleByProject
    {
        public List<DataUserRoleByProject> dataUserRoleByProject { get; set; }
        public List<EditDataUserRoleByProject> editDataUserRoleByProject { get;set; }
    }

    public class DataUserRoleByProject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public string IdRole { get; set; }
        public string IdUser { get; set; }
        public int  IdProject { get; set; }
    }

     public class EditDataUserRoleByProject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public string IdRole { get; set; }
        public string IdUser { get; set; }
        public int  IdProject { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string UrlImage { get; set; }
    }
 }
