using API.GFI.TestLanding;
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
            var build = (from b in db.Report
                         where b.id == idBuild
                         select new BuildModel
                         {
                             Id = b.id,
                             Date_start = b.date_start,
                             Date_end = b.date_end,
                             Status = b.status,
                             General_message = b.general_message,
                             Error_message = b.error_message,
                             Warning_message = b.warning_message,
                             Error_type = b.error_type,
                             Logs = b.logs,
                             Id_batteryTest = b.id_batteryTest,
                             Id_machine = b.id_machine,
                             Pass_tests = b.pass_tests,
                             Duration = b.duration,
                             Total_tests = b.total_tests,
                             FailedTests = b.failed_tests,
                             SkippedTests = b.skipped_tests,
                             //BatteryTest = b.BatteryTest,
                             //Machine = b.Machine

                         }).Single();

            return build;
        }

        [Route("api/GetBuildTests/{idBuild}")]
        public List<BuildTestsModel> GetBuildTests(int idBuild)
        {
            var tests = (from t in db.ReportCollection
                         where t.report_id == idBuild
                         select new BuildTestsModel
                         {
                            Id = t.id,
                            Date_start = t.date_start,
                            Date_end = t.date_end,
                            Status = t.status,
                            General_message = t.general_message,
                            Error_message = t.error_message,
                            Error_type = t.error_type,
                            Test_name = t.test_name,
                            Author = t.author,
                            Duration = t.duration,
                            Area = t.area,
                            Logs = t.logs,
                            Screenshot = t.screenshot,
                         }).ToList();

            return tests;
        }

        
        [Route("api/GetTest/{idTest}")]
        public BuildTestsModel GetTest(int idTest)
        {
            var test = (from t in db.ReportCollection
                         where t.id == idTest
                         select new BuildTestsModel
                         {
                             Id = t.id,
                             Date_start = t.date_start,
                             Date_end = t.date_end,
                             Status = t.status,
                             General_message = t.general_message,
                             Error_message = t.error_message,
                             Error_type = t.error_type,
                             Test_name = t.test_name,
                             Author = t.author,
                             Duration = t.duration,
                             Area = t.area,
                             Logs = t.logs,
                             Screenshot = t.screenshot,
                         }).Single();

            return test;
        }
    }
   }
