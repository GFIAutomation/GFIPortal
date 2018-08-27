using gfi_test_landing.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
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
            try
            {
                // Entity Framework can't call methods on join and LINQ syntax
                // Convert the Session UserID to a String
                String UserID = Session["UserID"].ToString();

                // Create a List with ProjectViewModel objects to be sent to the view
                var ProjectList = (from p in db.Project
                                    join ur in db.UserRole on p.id equals ur.id_project
                                    where ur.UserId == UserID
                                    select new ProjectViewModel { Id = p.id, ProjectName = p.name }).ToList();

                // Return the list to the View
                return View(ProjectList);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Project(string language, String project_id)
        {
            changeLanguage(language);
            
            // Transform the string into a number to be validated
            int prj = int.Parse(project_id);

            /* If the id is valid then create a session variable with
             * the project id
             */
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
                int chrome = db.Test.Where(x => x.broswer == "Google Chrome").Count();
                int firefox = db.Test.Where(x => x.broswer == "Firefox").Count();
                int ie = db.Test.Where(x => x.broswer == "IE").Count();
                int opera = db.Test.Where(x => x.broswer == "Opera").Count();
                int edge = db.Test.Where(x => x.broswer == "Edge").Count();
                int safari = db.Test.Where(x => x.broswer == "Safari").Count();

                Chart obj = new Chart();
                obj.Chrome = chrome.ToString();
                obj.Firefox = firefox.ToString();
                obj.IE = ie.ToString();
                obj.Opera = opera.ToString();
                obj.Edge = edge.ToString();
                obj.Safari = edge.ToString();

                return View(obj);
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