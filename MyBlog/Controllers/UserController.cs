using MyBlog.Models;
using MyBlog.Models.PostCommentViewModel;
using MyBlog.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class UserController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                var isExist = db.Users.Where(x =>  x.Username == user.Username).SingleOrDefault();

                if (isExist != null)
                {
                    ViewBag.message = "This username already used..";
                    return View();
                }
                var salt =PasswordHash.CreateSalt(4);
                String pw = user.Password + salt;
                var hashAndSalt = PasswordHash.GetPasswordHashAndSalt(pw);

                user.Password = hashAndSalt;
                user.Salt = salt;

                db.Users.Add(user);
                db.SaveChanges();
                Session["Username"] = user.Username;
                return RedirectToAction("Index", "Home");
            }
            return View("Signup", user);
            
        }

        public ActionResult SignIn()
        {


            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User user)
        {

                var isExist = db.Users.Where(x => x.Username == user.Username).SingleOrDefault();

                if (isExist != null)
                {
                    var salt = isExist.Salt;
                    var passwordAndSalt = user.Password + salt;
                    var hash =PasswordHash.GetPasswordHashAndSalt(passwordAndSalt);
                    if (isExist.Password == hash)
                    {
                        Session["Username"] = isExist.Username;
                        Session["User"] = isExist;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                
                        ViewBag.message = "Wrong id-password combination!";
                        return View();
                    }
                }
                else
                {
                    ViewBag.message = "No user found with these credentials..";
                    return View();
                }
                
              
          
        }
        public ActionResult SignOut()
        {
            Session["Username"] = null;
            Session["User"] = null;

            return RedirectToAction("Index","Home");
        }


        [HttpPost]
        public PartialViewResult AddComment(FormCollection form,int pid, int uid)
        {
            Comment com = new Comment();

            String check = form["text"].ToString();
            if (!String.IsNullOrEmpty(check))
            {
                com.description = form["text"];
                com.User = db.Users.Where(x => x.Id == uid).SingleOrDefault();
                com.Post = db.Posts.Where(x => x.Id == pid).SingleOrDefault();
                com.PublishDate = DateTime.Now;
                db.Comments.Add(com);
                db.SaveChanges();
                return PartialView(com);
            }
            else
            {
                return null;
            }
            

            
        }

        


    }
}