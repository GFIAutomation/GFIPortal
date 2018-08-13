using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gfi_test_landing.Models
{
    public class TestViewModel
    {
        [Required]
        [Display(Name = "Test Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string TestName { get; set; }

        [Required]
        [Display(Name = "Test Description")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string TestDescription { get; set; }

        [Required]
        [Display(Name = "Test Browser")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string TestBrowser { get; set; }
    }
}