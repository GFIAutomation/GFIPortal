using gfi_test_landing.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace gfi_test_landing.Controllers
{
    public class HomeController : Controller
    {
        private static int IdProject;
        
        [Authorize]
        public async Task<ActionResult> MyProjects()
        {
            //Get the userID from Session
            String UserID = Session["UserID"].ToString();
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59443/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/GetUserProjects/" + UserID);

                if (response.IsSuccessStatusCode)
                {
                    var projectsList = response.Content.ReadAsAsync<List<ProjectModel>>().Result;
                    return View(projectsList);
                }
                else
                {
                    return View();

                }
            }
}
        
        [HttpPost]
        [Authorize]
        public ActionResult MyProjects(String project_id)
        {
            IdProject = int.Parse(project_id);
            /* If the id is valid then create a session variable with
             * the project id*/
            if (project_id != null)
            {
                Session["projectId"] = project_id;
            }
            return RedirectToAction("Project");
        }
   

        [Authorize]
        public async Task<ActionResult> Project()
        {
           // int idproject = int.Parse(project_id);//= int.Parse(Session["projectId"].ToString());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59443/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/GetProject/" + IdProject);

                if (response.IsSuccessStatusCode)
                {
                   var project = response.Content.ReadAsAsync<ProjectModel>().Result;
                    Session["projectName"] = project.Name;
                    return View(project);
                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult Builds()
        {
            ViewBag.idProject = IdProject;
            return View();
        }

        public ActionResult Tests()
        {
            ViewBag.idProject = IdProject;
            return View();
        }
    }
}