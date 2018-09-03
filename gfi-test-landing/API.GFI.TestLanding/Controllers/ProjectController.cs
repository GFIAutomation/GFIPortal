using API.GFI.TestLanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Api.Controllers
{
    public class ProjectController : ApiController
    {
        private testLandingEntities db = new testLandingEntities();


        [Route("api/GetUserProjects/{idUser}")]
        public List<ProjectModel> GetProjects(string userId)
        {
            var ProjectList = (from p in db.Project
                               join ur in db.UserRole on p.id equals ur.id_project
                               where ur.UserId == userId
                               select new ProjectModel { Id = p.id, Name = p.name, Description = p.description, Logo_url = p.logo_url }).ToList();

            return ProjectList;
        }

        [Route("api/GetNumberPassedTests/{idProject}")]
        public int GetNumberPassedTests(int idProject)
        {
            var pass = (from p in db.Project
                        join r in db.Report on p.id equals idProject
                        where r.status == "passed"
                        select r.status).Count();

            return pass;
        }

        [Route("api/GetNumberFailedTests/{idProject}")]
        public int GetNumberFailedTests(int idProject)
        {
            var failed = (from p in db.Project
                          join r in db.Report on p.id equals idProject
                          where r.status == "Failed"
                          select r.status).Count();

            return failed;
        }

        [Route("api/GetDateLastBuilds/{idProject}")]
        public List<String> GetDateLastBuilds(int idProject)
        {

            var dateDesc = (from p in db.Project
                            join r in db.Report on p.id equals idProject
                            orderby r.date_end descending
                            select r.date_end.ToString()).Take(5).ToList();

            return dateDesc;
        }

        [Route("api/GetLastFiveTotal/{idProject}")]
        public List<int?> GetLastFiveTotal(int idProject)
        {
            var statusLastFiveTotal = (from p in db.Project
                                       join r in db.Report on p.id equals idProject
                                       orderby r.date_end descending
                                       select r.total_tests).Take(5).ToList();

            return statusLastFiveTotal; 
     }



   }
}
