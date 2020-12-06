using MyBlog.Models;
using MyBlog.Models.AdminPostViewModel;
using MyBlog.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlog.Controllers
{
    
    public class AdminController : Controller
    {
        DatabaseContext db = new DatabaseContext();
      
        [Authorize]
        public ActionResult AdminView()
        {
            //TODO//
            if (Session["Id"]!=null)
            {

                String sessionId = Session["Id"].ToString();
                int idd=Convert.ToInt32(sessionId);
                var currentAdmin = db.Admins.Where(x => x.Id == idd).SingleOrDefault();

                AdminPostViewModel model = new AdminPostViewModel();

                if (currentAdmin != null)
                {

                    model.Posts = currentAdmin.Posts.ToList();
                }
                return View(model);
            }
            return RedirectToAction("SignIn", "Admin");


        }

       

        public ActionResult SignIn()
        {


            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Admin admin)
        {

                var isExist = db.Admins.Where(x => x.Username == admin.Username).SingleOrDefault();

                if (isExist != null)
                {
                    if (isExist.Password == admin.Password)
                    {
                        FormsAuthentication.SetAuthCookie(admin.Username, false);
                        Session["Username"] = isExist.Username;
                        Session["Id"] = isExist.Id;
                        return RedirectToAction("AdminView", "Admin");
                    }
                    else
                    {
                        ViewBag.message = "Wrong Id-Password Combination";
                        return RedirectToAction("SignIn", "Admin");
                    }
                }
            else
            {
                ViewBag.message = "Wrong Id-Password Combination";
                return View();
            }
                
            
        }
        public ActionResult SignOut()
        {
            
            Session["Username"] = null;
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddPost()
        {
            return View();
        }
     
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost(Post model, HttpPostedFileBase uploadFile)
        {
            String sessionId = Session["Id"].ToString();
            int idd = Convert.ToInt32(sessionId);

            string path =Server.MapPath("~/images/") +uploadFile.FileName;
            uploadFile.SaveAs(path);
            model.ImgUrl = uploadFile.FileName;
            var currentAdmin = db.Admins.Where(x => x.Id == idd).SingleOrDefault();


            model.Admin = currentAdmin;
            model.Comments = null;
            model.PublishDate = DateTime.Now;

            db.Posts.Add(model);
            int result =db.SaveChanges();

            if (result > 0)
            {
                ViewBag.Result = "Gönderi başarıyla yüklendi!";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Gönderi yüklenirken hata oluştu!";
                ViewBag.Status = "danger";
            }

            return View();
        }
    }
}
