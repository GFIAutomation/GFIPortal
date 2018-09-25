using API.GFI.TestLanding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminController : ApiController
    {
        private testLandingEntities db = new testLandingEntities();

        [Route("api/GetProjects")]
        public List<ProjectModel> GetProjects()
        {
            var ProjectList = (from p in db.Project
                               select new ProjectModel
                               {
                                   Id = p.id,
                                   Name = p.name,
                                   Description = p.description,
                                   Logo_url = p.logo_url
                               }).ToList();

            return ProjectList;
        }


        [Route("api/CreateProject")]
        public HttpResponseMessage Post([FromBody]ProjectModel project)
        {
            try
            {
                Project p = new Project
                {
                    name = project.Name,
                    description = project.Description,
                    logo_url = project.Logo_url,
                    projectImage = project.ByteImage
                    
                };
                db.Project.Add(p);
                db.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, p);
                message.Headers.Location = new Uri(Request.RequestUri + p.name);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //private void SaveImage(ProjectModel model)
        //{
        //    if (model.Image != null)
        //    {
        //        string fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
        //        string extension = Path.GetExtension(model.ImageUrl.FileName);
        //        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //        model.Logo_url = "~/Images/" + fileName;
        //        //fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
        //        model.Image.SaveAs(fileName);
        //    }
        //    else
        //    {
        //        model.Logo_url = "~/Images/logo.png";
        //    }


        //}
    }
}
