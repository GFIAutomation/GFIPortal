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

        //Delete Project 
        [Route("api/DeleteProject/{projectId}")]
        public HttpResponseMessage Delete( int projectId)
        {
            try {  
            var project = db.Project.Find(projectId);
            if(project == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Project with Id = " + projectId + "Not Found");
            }
            db.Project.Remove(project);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // Update Project
        [Route("api/UpdateProject/{idProject, value}")]
        public void Put(int projectId, [FromBody]string value)
        {

        }
    }
}
