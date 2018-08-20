using gfi_test_landing.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var list = new SelectList(db.Project, "id", "name");            
            ViewBag.project_name = list.Skip(0).First().Text;
            ViewBag.project_id = list.Skip(0).First().Value;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Project(string language, String project_id)
        {
            changeLanguage(language);
            int prj = int.Parse(project_id);
            if (prj > 0)
            {
                Session["projectId"] = prj;
                return RedirectToAction("Dashboard");
            }
            else
                return View();
        }

        [Authorize]
        public ActionResult Dashboard(string language)
        {
            changeLanguage(language);

            // Initialize variable and reasigned at try catch
            int project_id = 0;

            // If a project has been selected then we have an ID variable on cache
            try
            {
                project_id = int.Parse(Session["projectId"].ToString());
            }
            catch(Exception e) { Console.Write(e); }

            // Only Show the dashboard in case a project has been selected
            if (project_id > 0)
            {
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

                return View(obj);
                //https://www.youtube.com/watch?v=20L-h1rKyvM
                //https://www.youtube.com/watch?v=AqayTPADGsg
            }

            // If no ID has been detected, send him back to the project action
            return RedirectToAction("Project");
        }

        [Authorize]
        public ActionResult Index(string language)
        {
            changeLanguage(language);
            return View();
        }
    }
}