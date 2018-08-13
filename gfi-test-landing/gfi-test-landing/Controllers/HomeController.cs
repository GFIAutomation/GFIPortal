using gfi_test_landing.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace gfi_test_landing.Controllers
{
    public class HomeController : Controller
    {
        private testLandingEntities db = new testLandingEntities();

        private void changeLanguage(string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }
        [Authorize]
        public ActionResult Project(string language)
        {
            changeLanguage(language);
            return View();
        }
        [Authorize]
        public ActionResult Dashboard(string language)
        {
            changeLanguage(language);

            // donut chart browsers
            int chrome = db.Test.Where(x => x.broswer == "Chrome").Count();
            int firefox = db.Test.Where(x => x.broswer == "Firefox").Count();
            int ie = db.Test.Where(x => x.broswer == "IE").Count();
            int opera = db.Test.Where(x => x.broswer == "Opera").Count();
            int edge = db.Test.Where(x => x.broswer == "Edge").Count();

            Chart obj = new Chart();
            obj.Chrome = chrome.ToString();
            obj.Firefox = firefox.ToString();
            obj.IE = ie.ToString();
            obj.Opera = opera.ToString();
            obj.Edge = edge.ToString();

            //bar chart last battery executed
            //var countPassed = db.BatteryTest.
            //    Join(db.BatteryTest)
                


            //int countFailed = db.BatteryTest.OrderByDescending(x => x.update_date).FirstOrDefault().Where(x => x.status == "Failed").Count();
            //int batteryId = db.BatteryTest.OrderByDescending(x => x.update_date).Select(id_battery);
            //string lastDate = db.BatteryTest.OrderByDescending(x => x.update_date).FirstOrDefault().ToString();
            //string batteryId = db.BatteryTest.Select(x=>x.id_battery).Where(x=> x

            return View(obj);

            //https://www.youtube.com/watch?v=20L-h1rKyvM
            //https://www.youtube.com/watch?v=AqayTPADGsg
        }

        //public class Brand
        //{
        //    public string Chrome { get; set; }
        //    public string Firefox { get; set; }
        //    public string IE { get; set; }
        //    public string Opera { get; set; }
        //    public string Edge { get; set; }
        //}

        [Authorize]
        public ActionResult Index(string language)
        {
            changeLanguage(language);
            return View();
        }
        
        [Authorize]
        public ActionResult Button()
        {
            return View();
        }
        [Authorize]
        public ActionResult TestCreate()
        {
            return View();
        }
        [Authorize]
        public ActionResult TestList()
        {
            return View();
        }
       
    }
}