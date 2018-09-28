using API.GFI.TestLanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {
        private testLandingEntities db = new testLandingEntities();

        [Route("api/GetUserProjects/{idUser}")]
        public List<ProjectModel> GetUserProjects(string idUser)
        {
            var ProjectList = (from p in db.Project
                               join ur in db.UserRole on p.id equals ur.id_project
                               where ur.UserId == idUser
                               select new ProjectModel
                               {
                                   Id = p.id,
                                   Name = p.name,
                                   Description = p.description,
                                   Logo_url = p.logo_url
                               }).ToList();

            return ProjectList;
        }



        [Route("api/GetProject/{idProject}")]
        public ProjectModel GetProject(int idProject)
        {
            var Project = (from p in db.Project
                           where p.id == idProject
                           select new ProjectModel
                           {
                               Id = p.id,
                               Name = p.name,
                               Description = p.description,
                               Logo_url = p.logo_url,
                               ByteImage = p.projectImage
                           }).Single();

            return Project;
        }
        //Builds substitui os Reports 
        [Route("api/GetBuilds/{idProject}")]
        public List<BuildModel> GetBuilds(int idProject)
        {
            var builds = (from b in db.Build
                          where b.id_project == idProject
                          select new BuildModel
                           {
                            Id = b.id,
                            Tool_name = b.tool_name,
                            Date_start = b.date_start,
                            Date_end = b.date_end,
                            Status = b.status,
                            General_message = b.general_message,
                            Id_batteryTest = b.id_batteryTest,
                            Id_machine = b.id_machine,
                            Pass_tests = b.pass_tests,
                            Duration = b.duration,
                            Total_tests = b.total_tests,
                            Failed_tests = b.failed_tests, 
                            Skipped_tests = b.skipped_tests,
                            Username = b.username
                          }).ToList();
            return builds;
        }

        [Route("api/GetLastTenBuilds/{idProject}")]
        public List<BuildModel> GetLastTenBuilds(int idProject)
        {
            var builds = (from b in db.Build
                          where b.id_project == idProject
                          orderby b.date_start descending
                          where b.status != "Running"
                          select new BuildModel
                          {
                              Id = b.id,
                              Tool_name = b.tool_name,
                              Date_start = b.date_start,
                              Date_end = b.date_end,
                              Status = b.status,
                              General_message = b.general_message,
                              Id_batteryTest = b.id_batteryTest,
                              Id_machine = b.id_machine,
                              Pass_tests = b.pass_tests,
                              Duration = b.duration,
                              Total_tests = b.total_tests,
                              Failed_tests = b.failed_tests,
                              Skipped_tests = b.skipped_tests,
                              Username = b.username
                          }).Take(10).ToList();

            builds.Reverse();
            return builds;
        }

        //Get total Builds, total tests...
        [Route("api/GetTotalBuilds/{idProject}")]
        public List<double> GetTotalBuilds(int idProject)
        {
            List<double> values = new List<double>();
            //Get Total Builds 
            var totalBuilds = (from b in db.Build
                               where b.id_project == idProject
                               select b.total_tests).Count();

            values.Add(totalBuilds);

            //Get Passed Builds
            var passedBuilds = (from b in db.Build
                                where b.id_project == idProject
                                where b.status == "Passed"
                                select b.status).Count();

            values.Add(passedBuilds);

            //Get Failed Builds
            var failedBuilds = (from b in db.Build
                                where b.id_project == idProject
                                where b.status == "Failed"
                                select b.status).Count();

            values.Add(failedBuilds);

            //Get Running Builds
            var RunningBuilds = (from b in db.Build
                                 where b.id_project == idProject
                                 where b.status == "Running"
                                 select b.status).Count();

            values.Add(RunningBuilds);


            //Percentage of Passed Builds
            var percentPassedBuilds = (passedBuilds * 100.00) / totalBuilds;
            values.Add(System.Math.Round(percentPassedBuilds, 2));
            //Percentage of Failed Builds
            var percentFailedBuilds = (failedBuilds * 100.00) / totalBuilds;
            values.Add(System.Math.Round(percentFailedBuilds, 2));

            return values;
        }


        [Route("api/GetTotalAndPercentageTests/{idProject}")]
        public List<double> GetTotalAndPercentageTests(int idProject)
        {
            List<double> tests = new List<double>();
            //Get total Tests
            var totalTests = (from t in db.Tools_Test
                              where t.id_project == idProject
                              select t).Count();

            tests.Add(totalTests);

            //Get Passed Builds
            var passedTests = (from t in db.Tools_Test
                               where t.id_project == idProject
                               where t.status == "Passed"
                               select t).Count();

            tests.Add(passedTests);

            //Get Failed Builds
            var failedTests = (from t in db.Tools_Test
                               where t.id_project == idProject
                               where t.status == "Failed"
                               select t).Count();

            tests.Add(failedTests);

            //Get Running Builds
            var RunningTests = (from t in db.Tools_Test
                                where t.id_project == idProject
                                where t.status == "Running"
                                select t).Count();

            tests.Add(RunningTests);


            //Percentage of Passed Tests
            var percentPassedTests = (passedTests * 100.00) / totalTests;
            tests.Add(System.Math.Round(percentPassedTests, 2));
            //Percentage of Failed Tests
            var percentFailedTests = (failedTests * 100.00) / totalTests;
            tests.Add(System.Math.Round(percentFailedTests, 2));

            return tests;
        }


        //Builds tests 
        [Route("api/GetNumberPassedTests/{idProject}")]
        public int GetNumberPassedTests(int idProject)
        {
            var pass = (from t in db.Tools_Test
                        where t.id_project == idProject
                        where t.status == "passed"
                        select t.status).Count();

            return pass;
        }


        //Builds tests
        [Route("api/GetNumberFailedTests/{idProject}")]
        public int GetNumberFailedTests(int idProject)
        {
            var failed = (from t in db.Tools_Test
                          where t.id_project == idProject
                          where t.status == "Failed"
                          select t.status).Count();

            return failed;
        }


       

        //Project Tests (Build Tests Model substitui o ReportCollection)
        [Route("api/GetTests/{idProject}")]
        public List<BuildTestsModel> GetTests(int idProject)
        {
            var tests = (from t in db.ReportCollection
                         where t.project_id == idProject
                         select new BuildTestsModel
                         {
                             Id = t.id,
                             Report_id = t.report_id,
                             Date_start = t.date_start,
                             Date_end = t.date_end,
                             Status = t.status,
                             General_message = t.general_message,
                             Error_message = t.error_message,
                             Error_type = t.error_type,
                             Logs = t.logs,
                             Test_name = t.test_name,
                             Author = t.author,
                             Duration = t.duration,
                             Area = t.area,
                             Screenshot = t.screenshot

                         }).ToList();

            return tests;
        }




        //Get the last 5 tests
        [Route("api/GetLastFiveTotal/{idProject}")]
        public List<int?> GetLastFiveTotal(int idProject)
        {
            var statusLastFiveTotal = (from p in db.Project
                                       join r in db.Report on p.id equals idProject
                                       orderby r.date_end descending
                                       select r.total_tests).Take(5).ToList();

            return statusLastFiveTotal;
        }


        //Get last 5 passed tests
        [Route("api/GetLastFivePassedTests/{idProject}")]
        public List<int?> GetLastFivePassedTests(int idProject)
        {
            var statusLastFivePass = (from p in db.Project
                                      join r in db.Report on p.id equals idProject
                                      orderby r.date_end descending
                                      select r.pass_tests).Take(5).ToList();

            return statusLastFivePass;
        }


        //Get the last 5 failed tests
        [Route("api/GetLastFiveFailedTests/{idProject}")]
        public List<long?> GetLastFiveFailedTests(int idProject)
        {
            var statusLastFiveTotal = (from p in db.Project
                                       join r in db.Report on p.id equals idProject
                                       orderby r.date_end descending
                                       select r.total_tests).Take(5).ToList();

            var statusLastFivePass = (from p in db.Project
                                      join r in db.Report on p.id equals idProject
                                      orderby r.date_end descending
                                      select r.pass_tests).Take(5).ToList();

            List<long?> statusLastFiveFail = new List<long?>();
            for (int i = 0; i < 5; i++)
            {
                statusLastFiveFail.Add(statusLastFiveTotal[i] - statusLastFivePass[i]);
            }

            return statusLastFiveFail;
        }


    }
}
