using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gfi_test_landing;

namespace gfi_test_landing.Models
{
    public class TestViewModel
    {
        public gfi_test_landing.Test test;
        public IEnumerable<gfi_test_landing.Step> actionList;
        public dynamic steps;
    }
}