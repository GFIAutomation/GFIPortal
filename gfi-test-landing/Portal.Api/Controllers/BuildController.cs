using API.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace API.Api.Controllers
{
    public class BuildController : ApiController
    {
        private testLandingEntities db = new testLandingEntities();

        public List<ReportModel> GetReportList(int id_project)
        {
            var idReport = db.Report.Select(r => r.id).ToList();
            
            // Create a List with ProjectViewModel objects to be sent to the view

            var ReportList = (from r in db.Report
                              join rc in db.ReportCollection on r.id equals rc.report_id
                              join p in db.Project on rc.project_id equals p.id
                              where p.id == id_project
                              select new Models.ReportModel {
                                  Id = r.id,
                                  Date_start = r.date_start.Value,
                                  Date_end = r.date_end.Value,
                                  Status = r.status,
                                  General_message = r.general_message }).ToList();

            return ReportList;
        }
    }
}
