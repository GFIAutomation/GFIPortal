using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gfi_test_landing.Models
{
    public class ReportViewModel
    {
        [Required]
        [Display(Name = "Date start")]
        [StringLength(100, ErrorMessage = "Date must be 12 digits long", MinimumLength = 3)]
        public string DateStart { get; set; }

        [Required]
        [Display(Name = "Date end")]
        [StringLength(100, ErrorMessage = "Date must be 12 digits long", MinimumLength = 3)]
        public string DateEnd { get; set; }

        public string Duration { get; set; }

        public int? Pass_tests { get; set; }

        public int? Total_tests { get; set; }

        public string Status { get; set; }

        public string GeneralMessage { get; set; }

        public int Id { get; set; }

    }

}