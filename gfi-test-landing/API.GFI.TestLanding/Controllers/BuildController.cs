using API.GFI.TestLanding;
using API.GFI.TestLanding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.GFI.TestLanding
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BuildController : ApiController
    {
        private testLandingEntities db = new testLandingEntities();

        [Route("api/GetBuild/{idBuild}")]
        public BuildModel GetBuild(int idBuild)
        {
            var build = (from b in db.Build
                         where b.id == idBuild
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

                         }).Single();

            return build;
        }

        [Route("api/GetBuildTests/{idBuild}")]
        public List<ToolsTest> GetBuildTests(int idBuild)
        {
            var tests = (from t in db.Tools_Test
                         where t.id_build == idBuild
                         select new ToolsTest
                         {
                          Id = t.id,      
                          Name = t.name,
                          Status = t.status,
                          Date_start = t.date_start,
                          Date_end = t.date_end, 
                          Duration = t.duration,
                          Browser = t.browser,
                          Site = t.site,
                          General_message = t.general_message, 
                          Description = t.description,
                          Error_message = t.error_message

                            }).ToList();

            return tests;
        }

        
        [Route("api/GetTest/{idTest}")]
        public ToolsTest GetTest(int idTest)
        {
            var test = (from t in db.Tools_Test
                        where t.id == idTest
                        select new ToolsTest
                         {
                            Id = t.id,
                            Name = t.name,
                            Status = t.status,
                            Date_start = t.date_start,
                            Date_end = t.date_end,
                            Duration = t.duration,
                            Browser = t.browser,
                            Site = t.site,
                            General_message = t.general_message,
                            Description = t.description,
                            Error_message = t.error_message
                        }).Single();

            return test;
        }
    }
   }
