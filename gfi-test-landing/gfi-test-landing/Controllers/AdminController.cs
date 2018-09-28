using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using gfi_test_landing.Models;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using System.Threading;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Drawing;

namespace gfi_test_landing.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private testLandingEntities db = new testLandingEntities();

        private void changeLanguage(string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }

        // GET: AddUserToProject
        [Authorize]
        public ActionResult AddUserToProject(int? idProject, string idUser)
        {


            if (idProject != null)
            {
                ViewBag.ProjectName = db.Project.Where(p => p.id == idProject).Select(p => p.name).Single();
                getUserWithoutProjectDropDown(idProject);
            }
            if (idUser != null)
            {
                ViewBag.UserName = db.AspNetUsers.Where(u => u.Id == idUser).Select(u => u.UserName).Single();
                getProjectWithoutUserDropDown(idUser);
            }

            if (idProject <= 0 && idUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var roleDropDown = db.AspNetRoles;


            List<SelectListItem> itemsRole = new List<SelectListItem>();
            foreach (var u in roleDropDown)
            {
                SelectListItem a = new SelectListItem();
                a.Text = u.Name.ToString();
                a.Value = u.Id.ToString();
                itemsRole.Add(a);
            }

            ViewBag.DropRole = new SelectList(itemsRole.AsEnumerable(), "Value", "Text");

            AddUserToProjectViewModel model = new AddUserToProjectViewModel
            {
                IdProject = idProject,
                IdUser = idUser,
                dropListProject = ViewBag.projectList,
                dropListUser = ViewBag.userList

            };

            return View(model);
        }



        // POST: AddUserToProject
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddUserToProject(AddUserToProjectViewModel model)
        {
            //Save the date in table User roles

            UserRole userRole = new UserRole();
            if (model.IdProject != null)
            {

                userRole.id_project = (int)model.IdProject;
                userRole.UserId = model.DropIdUser;
                userRole.RoleId = model.DropIdRole;
                userRole.date = DateTime.Now;

                db.UserRole.Add(userRole);

                await db.SaveChangesAsync();
                ViewBag.Message = "O utilizador foi adicionado com sucesso.";
                ViewBag.Class = "alert-success";

                ViewBag.ProjectName = db.Project.Where(p => p.id == model.IdProject).Select(p => p.name).Single();
                getUserWithoutProjectDropDown(model.IdProject);
            }

            if (model.IdUser != null)
            {
                userRole.id_project = model.DropIdProject;
                userRole.UserId = model.IdUser;
                userRole.RoleId = model.DropIdRole;
                userRole.date = DateTime.Now;

                db.UserRole.Add(userRole);

                await db.SaveChangesAsync();
                ViewBag.Message = "O utilizador foi adicionado com sucesso.";
                ViewBag.Class = "alert-success";

                ViewBag.UserName = db.AspNetUsers.Where(u => u.Id == model.IdUser).Select(u => u.UserName).Single();
                getProjectWithoutUserDropDown(model.IdUser);
            }

            var userDropDown = db.AspNetUsers;


            var roleDropDown = db.AspNetRoles;


            List<SelectListItem> itemsRole = new List<SelectListItem>();
            foreach (var u in roleDropDown)
            {
                SelectListItem a = new SelectListItem();
                a.Text = u.Name.ToString();
                a.Value = u.Id.ToString();
                itemsRole.Add(a);
            }

            ViewBag.DropRole = new SelectList(itemsRole.AsEnumerable(), "Value", "Text");

            //AddUserToProjectViewModel modelF = new AddUserToProjectViewModel
            //{
            //    IdProject = model.IdProject,
            //    IdUser = model.IdUser,
            //    DropIdRole = "",
            //    DropIdUser = ""
            //};



            return View();
        }


        // GET: AspNetUsers/EditUserRoleByProject
        [Authorize]
        public ActionResult EditUserRoleByProject(int idProject, string idUser, string idRole)
        {

            //Verificar o if
            if (idProject.Equals("") || idProject <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<EditDataUserRoleByProject> DataUserRoleByProject = (from ur in db.UserRole
                                                                     join u in db.AspNetUsers on ur.UserId equals u.Id
                                                                     join r in db.AspNetRoles on ur.RoleId equals r.Id
                                                                     join p in db.Project on ur.id_project equals p.id
                                                                     where ur.UserId == idUser && ur.id_project == idProject
                                                                     select new EditDataUserRoleByProject()
                                                                     {
                                                                         IdProject = idProject,
                                                                         IdUser = ur.UserId,
                                                                         IdRole = ur.RoleId,
                                                                         FirstName = u.FirstName,
                                                                         LastName = u.LastName,
                                                                         Username = u.UserName,
                                                                         RoleName = r.Name,
                                                                         ProjectDescription = p.description,
                                                                         ProjectName = p.name,
                                                                         UrlImage = p.logo_url


                                                                     }).ToList();

            UserRoleByProject userRoleByProject = new UserRoleByProject()
            {
                editDataUserRoleByProject = DataUserRoleByProject
            };

            getRolesAndProjectsDropDownEdit(idProject, idRole);

            return View(userRoleByProject);
        }


        // POST: /Admin/EditUserRoleByProject
        [HttpPost, ActionName("EditRoleProjectByUser")]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserRoleByProject(DropRoleProjectByUserModel DropRoleProjetByUser, FormCollection form)
        {


            return RedirectToAction("Details", "Admin", new { id = DropRoleProjetByUser.IdUser });

        }

        //GET  PartialView AspNetUsers/Details/
        //_UserRoleByProject
        [Authorize]
        public ActionResult _UserRoleByProject(int id)
        {
            List<DataUserRoleByProject> roleUserByProject = (from ur in db.UserRole
                                                             join u in db.AspNetUsers on ur.UserId equals u.Id
                                                             join r in db.AspNetRoles on ur.RoleId equals r.Id
                                                             where ur.id_project == id
                                                             select new DataUserRoleByProject()
                                                             {
                                                                 IdProject = id,
                                                                 IdUser = ur.UserId,
                                                                 IdRole = ur.RoleId,
                                                                 FirstName = u.FirstName,
                                                                 LastName = u.LastName,
                                                                 Username = u.UserName,
                                                                 RoleName = r.Name

                                                             }).ToList();

            UserRoleByProject userRoleProjectModel = new UserRoleByProject
            {
                //Id = id,
                dataUserRoleByProject = roleUserByProject
            };
            if (userRoleProjectModel == null)
            {
                //Then Error

            }
            return PartialView(userRoleProjectModel);

        }

        //
        //GET: /Admin/DetailsProject
        [Authorize]
        public ActionResult DetailsProject(int id)
        {
            string Id = id.ToString();
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(getValuesDetailsProject(id));
        }

        //
        // POST:/Admin/DetailsProject
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> DetailsProject(ProjectViewModel pVM)
        {

            //Conta quantos projectos ha com aquele nome
            var isExist = db.Project.Where(p => p.name == pVM.ProjectName).Count();
            var idValid = db.Project.Where(p => p.name == pVM.ProjectName).Select(p => p.id).First();


            string Id = pVM.Id.ToString();
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (isExist == 1 && idValid == pVM.Id)
            {
                isExist = 0;
            }

            //Se tem o mesmo nome valor é 1 se não existe é 0 
            if (ModelState.IsValid && isExist == 0)
            {
                Project projectRow = db.Project.Single(p => p.id == pVM.Id);
                projectRow.name = pVM.ProjectName;
                projectRow.description = pVM.ProjectDescription;
                //projectRow.logo_url = pVM.UrlImage;

                db.Entry(projectRow).State = EntityState.Modified;
                await db.SaveChangesAsync();


                //  DisplayComponent displayComponent = new DisplayComponent();
                var listInsertProjectComponent = new List<DisplayComponent>();

                for (int i = 0; i < pVM.Components.Count(); i++)
                {

                    listInsertProjectComponent.Add(new DisplayComponent
                    {

                        id_project = pVM.Id,
                        id_component = pVM.Components[i].Id,
                        visible = pVM.Components[i].IsSelected


                    });

                };

                foreach (var listProjectComponent in listInsertProjectComponent)
                {
                    DisplayComponent displayC = db.DisplayComponent.SingleOrDefault(dc => dc.id_component == listProjectComponent.id_component && dc.id_project == listProjectComponent.id_project);

                    displayC.visible = listProjectComponent.visible;


                    db.Entry(displayC).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();




            }
            else
            {
                //Model invalido ou Já existe um projecto com esse nome
                //ERROR
            }


            return View(getValuesDetailsProject(pVM.Id));
        }


        //Não esta a ser usado
        //GET: /Admin/ProjectList
        [Authorize]
        public ActionResult ProjectList()
        {
            var projectList = db.Project.Select(t => t);
            return View(projectList.ToList());
        }



        //GET: /Admin/CreateProject - i am using this  and the next one
        [Authorize]
        public ActionResult CreateProject()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult CreateProject(ProjectModel project)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59443/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Convert Image to Byte [] 
                if (project.Image != null)
                {
                    project.ByteImage = new byte[project.Image.ContentLength];
                    project.Image.InputStream.Read(project.ByteImage, 0, project.Image.ContentLength);
                    project.Image = null;
                }

                //To send http Content serialize the object, encode and make it ByteArrayContent
                var content = JsonConvert.SerializeObject(project);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //Convert Image to Database Format

                var result = client.PostAsync("api/CreateProject", byteContent).Result;


                if (result.IsSuccessStatusCode)
                {
                    var responseProject = result.Content.ReadAsAsync<ProjectModel>().Result;
                    return View(responseProject);
                }
                else
                {
                    return View();
                }
            }
        }



        public async Task<ActionResult> ProjectDetails(int ProjectId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59443/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/GetProject/" + ProjectId);

                if (response.IsSuccessStatusCode)
                {
                    var project = response.Content.ReadAsAsync<ProjectModel>().Result;
                    if(project.ByteImage != null)
                    {
                        var base64 = Convert.ToBase64String(project.ByteImage);
                        var imageSrc = String.Format("data:image/gif;base64,{0}", base64);
                        project.Logo_url = imageSrc;
                    }
                    return View(project);
                }
                else
                {
                    return View();
                }
            }
        }

        //another easy way to convert image to bytearray
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }



        //GET: /Admin/UserList
        [Authorize]
        public ActionResult UserList()
        {
            var userList = db.AspNetUsers.Select(t => t);
            return View(userList.ToList());

        }

        // GET: AspNetUsers/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);



            //if (userRoleProjectModel != null)
            //{
            //    _RoleProjectByUser( roleUserByProj);
            //    //PartialView("~/Views/Shared/_ListProjectUser.cshtml", model);
            //}

            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }


            return View(aspNetUsers);
        }

        // GET: AspNetUsers/Details/5
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Details([Bind(Include = "Id,Email,PhoneNumber,ImageUrl,FirstName,LastName")] AspNetUsers aspNetUsers)
        {
            if (ModelState.IsValid)
            {
                AspNetUsers userRow = db.AspNetUsers.Single(u => u.Id == aspNetUsers.Id);
                userRow.Email = aspNetUsers.Email;
                userRow.PhoneNumber = aspNetUsers.PhoneNumber;
                userRow.ImageUrl = aspNetUsers.ImageUrl;
                userRow.FirstName = aspNetUsers.FirstName;
                userRow.LastName = aspNetUsers.LastName;
                db.Entry(userRow).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return View(aspNetUsers);
            }
            return View(aspNetUsers);
        }

        //GET  PartialView AspNetUsers/Details/5
        [Authorize]
        public ActionResult _RoleProjectByUser(string id)
        {
            IEnumerable<RoleProjectByUserModel> roleUserByProj = (from ur in db.UserRole
                                                                  join p in db.Project on ur.id_project equals p.id
                                                                  join r in db.AspNetRoles on ur.RoleId equals r.Id
                                                                  where ur.UserId == id
                                                                  select new RoleProjectByUserModel()
                                                                  {
                                                                      IdUser = id,
                                                                      IdRole = r.Id,
                                                                      IdProject = p.id,
                                                                      NameRole = r.Name,
                                                                      NameProject = p.name,
                                                                      DescriptionProject = p.description
                                                                  }).ToList();

            UserRoleProjectModel userRoleProjectModel = new UserRoleProjectModel
            {
                //Id = id,
                RoleProjetByUser = roleUserByProj
            };
            if (userRoleProjectModel == null)
            {
                //Then Error

            }
            return PartialView(roleUserByProj);

        }

        //// GET: AspNetUsers/Edit/5
        //[Authorize]
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
        //    if (aspNetUsers == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUsers);
        //}

        //// POST: AspNetUsers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Email,PhoneNumber,ImageUrl,FirstName,LastName")] AspNetUsers aspNetUsers)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AspNetUsers userRow = db.AspNetUsers.Single(u => u.Id == aspNetUsers.Id);
        //        userRow.Email = aspNetUsers.Email;
        //        userRow.PhoneNumber = aspNetUsers.PhoneNumber;
        //        userRow.ImageUrl = aspNetUsers.ImageUrl;
        //        userRow.FirstName = aspNetUsers.FirstName;
        //        userRow.LastName = aspNetUsers.LastName;
        //        db.Entry(userRow).State = EntityState.Modified;

        //        await db.SaveChangesAsync();
        //        return RedirectToAction("UserList");
        //    }
        //    return View(aspNetUsers);
        //}

        //DELETE with modal
        [Authorize]
        public ActionResult _ModalDelete(String id, String actionName, String idUser, String idRole, String idProject)
        {
            if (actionName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (actionName == "UserList")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
                TempData["title"] = "User";
                TempData["Msg"] = "Do you want to delete the " + aspNetUsers.Email + " ?";
                return PartialView("_ModalDelete");
            }

            if (actionName == "ProjectList")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Project project = db.Project.Find(Int64.Parse(id));
                TempData["title"] = "Project";
                TempData["Msg"] = "Do you want to delete the " + project.name + " ?";
                return PartialView("_ModalDelete");
            }

            if (actionName == "roleProjectByUser")
            {
                if (idRole == null || idProject == null || idUser == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TempData["title"] = "Association";
                TempData["Msg"] = "Do you want to delete this Row?";
                return PartialView("_ModalDelete");
            }
            return PartialView();
        }


        //POST
        //_ModalDeleteConfirm
        [HttpPost, ActionName("_ModalDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _ModalDeleteConfirmed(String id, String actionName, String idUser, String idRole, String idProject)
        {
            if (actionName == "UserList")
            {
                AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);

                db.AspNetUsers.Remove(aspNetUsers);

                try
                {
                    await db.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    ex.ToString();

                    //Show message error
                }
            }

            if (actionName == "ProjectList")
            {
                Project project = db.Project.Find(Int64.Parse(id));

                //Verificar se ha alguma FK com aquele Id

                db.Project.Remove(project);
                try
                {
                    await db.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    ex.ToString();

                    //Show message error
                }
                return RedirectToAction("ProjectList", "Admin");


            }
            if (actionName == "roleProjectByUser")
            {
                int idPro = int.Parse(idProject);
                UserRole userRole = db.UserRole.Where(ur => ur.UserId == idUser && ur.RoleId == idRole && ur.id_project == idPro).First();

                if (userRole == null)
                {
                    //Error
                }
                db.UserRole.Remove(userRole);
                await db.SaveChangesAsync();

                return RedirectToAction("Details", "Admin", new { id = id });
            }
            return RedirectToAction("UserList");
        }

        // GET: AspNetUsers/Edit/5
        [Authorize]
        public ActionResult EditRoleProjectByUser(string idUser, int idProject, string idRole)
        {
            ViewBag.idUser = idUser;
            ViewBag.idProject = idProject;
            ViewBag.idRole = idRole;

            if (idUser == null || idProject.ToString() == null || idRole == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ViewBag.roleList == null && ViewBag.projectList == null)
            {
                getRolesAndProjectsDropDownEdit(idProject, idRole);
            }



            if (ViewBag.DropRole == null)
            {
                //ERROR
            }

            IEnumerable<DropRoleProjectByUserModel> DropRoleProjetByUser = DropDownRoleProjetByUser(idUser, idProject, idRole);

            if (DropRoleProjetByUser == null)
            {
                return HttpNotFound();
            }

            return View(DropRoleProjetByUser);
        }


        // POST: /Admin/EditRoleProjectByUser
        [HttpPost, ActionName("EditRoleProjectByUser")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRoleProjectByUser(DropRoleProjectByUserModel DropRoleProjetByUser, FormCollection form)
        {
            if (ViewBag.DropRole == null && ViewBag.DropProject == null)
            {
                getRolesAndProjectsDropDownEdit(DropRoleProjetByUser.IdProject, DropRoleProjetByUser.IdRole);
            }


            string idRoleChange = form["DropRole"].ToString();

            int idProjectChange = 0;
            if (form["DropProject"] != null && form["DropProject"] != "")
            {
                idProjectChange = Int32.Parse(form["DropProject"]);
            }

            UserRole userRole = db.UserRole.Where(ur => ur.id_project == DropRoleProjetByUser.IdProject && ur.RoleId == DropRoleProjetByUser.IdRole && ur.UserId == DropRoleProjetByUser.IdUser).FirstOrDefault();

            DropDownRoleProjetByUser(DropRoleProjetByUser.IdUser, DropRoleProjetByUser.IdProject, DropRoleProjetByUser.IdRole);

            if (userRole != null)
            {
                db.UserRole.Remove(userRole);
                await db.SaveChangesAsync();
            }
            else
            {
                //ERROR
            }

            UserRole userRoleInsert = new UserRole();

            if (idRoleChange != DropRoleProjetByUser.IdRole || idProjectChange != DropRoleProjetByUser.IdProject || idRoleChange != "")
            {
                if (idProjectChange == 0)
                {
                    idProjectChange = DropRoleProjetByUser.IdProject;
                }

                if (DropRoleProjetByUser.IdRole != idRoleChange && idRoleChange != "")
                {
                    DropRoleProjetByUser.IdRole = idRoleChange;
                }

                userRoleInsert.RoleId = DropRoleProjetByUser.IdRole;
                userRoleInsert.id_project = idProjectChange;
                userRoleInsert.UserId = DropRoleProjetByUser.IdUser;
                userRoleInsert.date = DateTime.Now;

                db.UserRole.Add(userRoleInsert);

                await db.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Admin", new { id = DropRoleProjetByUser.IdUser });

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //
        // GET: /Admin/Register
        [Authorize]
        public ActionResult Register()
        {

            if (ViewBag.roleList == null && ViewBag.projectList == null)
            {
                getRolesAndProjectsDropDown();
            }


            return View();
        }

        //
        // POST: /Admin/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ViewBag.roleList == null && ViewBag.projectList == null)
            {
                getRolesAndProjectsDropDown();
            }


            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber, FirstName = model.FirstName, LastName = model.LastName };
                var result = await UserManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);


                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //return RedirectToAction("Dashboard", "Home");
                    //var userId = User.Identity.GetUserId();
                    //var userId = (from s in db.AspNetUsers
                    //            where s.Email == model.Email
                    //             select s.Id).ToString();
                    // await this.UserManager.AddToRolesAsync(user.Id,model.NameRole);

                    saveUserProject(model, user);


                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ProjectViewModel getValuesDetailsProject(int id)
        {
            var componentsList = db.Component.Select(x => x).Count();

            List<Components> displayComponents;

            displayComponents = (from dc in db.DisplayComponent

                                 join c in db.Component on dc.id_component equals c.id
                                 where dc.id_project == id
                                 select new Components()
                                 {
                                     Id = c.id,
                                     Name = c.name,
                                     IsSelected = dc.visible

                                 }).ToList();

            var dataProject = db.Project.Find(id);

            var model = new ProjectViewModel
            {
                Id = id,
                ProjectName = dataProject.name,
                ProjectDescription = dataProject.description,
                UrlImage = dataProject.logo_url,
                Components = displayComponents
            };

            return model;
        }

        private IEnumerable<DropRoleProjectByUserModel> DropDownRoleProjetByUser(string idUser, int idProject, string idRole)
        {

            IEnumerable<DropRoleProjectByUserModel> DropRoleProjetByUser = (from ur in db.UserRole
                                                                            join p in db.Project on ur.id_project equals p.id
                                                                            join u in db.AspNetUsers on ur.UserId equals u.Id
                                                                            join r in db.AspNetRoles on ur.RoleId equals r.Id
                                                                            where (u.Id == idUser && p.id == idProject && r.Id == idRole)

                                                                            select new DropRoleProjectByUserModel()
                                                                            {
                                                                                Email = u.Email,
                                                                                FirstName = u.FirstName,
                                                                                LastName = u.LastName,
                                                                                ImageUser = u.ImageUrl,
                                                                                PhoneNumber = u.PhoneNumber,
                                                                                NameRole = r.Name,
                                                                                NameProject = p.name,
                                                                                IdProject = p.id,
                                                                                IdRole = r.Id,
                                                                                IdUser = u.Id

                                                                            }).ToList();

            return DropRoleProjetByUser;
        }

        private void getUserWithoutProjectDropDown(int? idProject)
        {
            var usersIDs = (from ur in db.UserRole
                            join u in db.AspNetUsers on ur.UserId equals u.Id
                            where ur.id_project != idProject
                            select u);


            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var t in usersIDs)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.UserName.ToString();
                s.Value = t.Id.ToString();
                items.Add(s);
            }
            ViewBag.userList = items;

        }

        private void getProjectWithoutUserDropDown(string idUser)
        {
            var projectsIDs = (from ur in db.UserRole
                               join p in db.Project on ur.id_project equals p.id
                               where ur.UserId != idUser
                               select p);

            var projectIDs = db.Project.Select(x => x);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var t in projectsIDs)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.name.ToString();
                s.Value = t.id.ToString();
                items.Add(s);
            }
            ViewBag.projectList = items;

        }

        private void getRolesAndProjectsDropDown()
        {
            var roleIDs = db.AspNetRoles.Select(x => x);
            var projectIDs = db.Project.Select(x => x);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var t in roleIDs)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.Name.ToString();
                s.Value = t.Id.ToString();
                items.Add(s);
            }
            ViewBag.roleList = items;

            List<SelectListItem> itemsProject = new List<SelectListItem>();
            foreach (var p in projectIDs)
            {
                SelectListItem a = new SelectListItem();
                a.Text = p.name.ToString();
                a.Value = p.id.ToString();
                itemsProject.Add(a);
            }
            ViewBag.roleList = items;
            ViewBag.projectList = itemsProject;

        }

        private void getRolesAndProjectsDropDownEdit(int idProject, string idRole)
        {
            var roleIDs = db.AspNetRoles.Select(x => x).Where(x => x.Id != idRole);
            var projectIDs = db.Project.Select(x => x).Where(x => x.id != idProject);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var t in roleIDs)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.Name.ToString();
                s.Value = t.Id.ToString();
                items.Add(s);
            }
            ViewBag.roleList = items;

            List<SelectListItem> itemsProject = new List<SelectListItem>();
            foreach (var p in projectIDs)
            {
                SelectListItem a = new SelectListItem();
                a.Text = p.name.ToString();
                a.Value = p.id.ToString();
                itemsProject.Add(a);
            }

            ViewBag.DropRole = new SelectList(items.AsEnumerable(), "Value", "Text", idRole);
            ViewBag.DropProject = new SelectList(itemsProject.AsEnumerable(), "Value", "Text", idProject);
        }

        private void saveUserProject(RegisterViewModel model, ApplicationUser user)
        {
            UserRole userRole = new UserRole();

            userRole.id_project = model.IdProject;
            userRole.UserId = user.Id;
            userRole.RoleId = model.NameRole;
            userRole.date = DateTime.Now;

            db.UserRole.Add(userRole);

            db.SaveChanges();
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Dashboard", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    
        
     

    }
}