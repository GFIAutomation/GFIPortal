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


        [Route("api/GetBuildList/{idproject}")]
        public List<BuildModel> GetBuildList(int idproject)
        {
                 
            var buildList = (from r in db.Report
                              join rc in db.ReportCollection on r.id equals rc.report_id
                              join p in db.Project on rc.project_id equals p.id
                              where p.id == idproject
                              select new BuildModel {
                                  Id = r.id,
                                  Date_start = r.date_start.Value,
                                  Date_end = r.date_end.Value,
                                  Status = r.status,
                                  General_message = r.general_message }).Distinct().ToList();

            return buildList;
        }



        [Route("api/GetReportList/{idproject}")]
        public List<ReportModel> GetReportCollection(int idProject)
        {
            var reportList = (from p in db.Report
                              join ur in db.ReportCollection on p.id equals ur.project_id
                              join r in db.Report on ur.report_id equals r.id
                              where ur.report_id == idProject
                              select new ReportModel {
                                  Author = ur.author, Project_id = idProject,
                                  Test_name = ur.test_name, Id = ur.id, Date_start = ur.date_start.Value,
                                  Date_end = ur.date_end.Value, Status = ur.status,
                                  General_message = ur.general_message }).ToList();

            return reportList;
        }


        [Route("api/GetReport/{idReport}")]
        public ReportModel GetReport(int idReport)
        {
            ReportModel report = (ReportModel)(from r in db.ReportCollection where r.report_id == idReport select new ReportModel
            {
                Author = r.author, Project_id = (int)r.project_id,
                Test_name = r.test_name,
                Id = r.id,
                Date_start = r.date_start.Value,
                Date_end = r.date_end.Value,
                Status = r.status,
                General_message = r.general_message
            });

            return report;
        }
    }  
}
