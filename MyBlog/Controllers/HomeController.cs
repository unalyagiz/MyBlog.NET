using MyBlog.Models;
using MyBlog.Models.AdminPostViewModel;
using MyBlog.Models.PostCommentViewModel;
using MyBlog.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
             db.Database.Initialize(true);

            AdminPostViewModel apm = new AdminPostViewModel();
            List<Post> post = db.Posts.OrderByDescending(x => x.PublishDate).ToList();

            apm.Posts = post;
            return View(apm);
        }

        public ActionResult DetailedPost(int? postid)
        {
            Post post = null;
            PostCommentViewModel model = new PostCommentViewModel();
            if (postid != null)
            {
                
                post = db.Posts.Where(x => x.Id == postid).SingleOrDefault();
                //List<Post> post = db.Posts.Where(x=>x.Post.Id).OrderByDescending(x => x.PublishDate).ToList();
                post.Comments = db.Comments.Where(x => x.Post.Id==postid).OrderByDescending(x => x.PublishDate).ToList();

                //post.Comments = db.Comments.Where(x => x.Post.Id == postid).ToList();

                
                model.comments = post.Comments;
                model.post = post;
                
            }

            return View(model);
        }

        [HttpPost]
        public PartialViewResult Search(String veri="")
        {
            List<Post> filteredPosts =db.Posts.Where(x => x.Description.Contains(veri)|| x.Title.Contains(veri)).ToList();
            AdminPostViewModel apm = new AdminPostViewModel();
            apm.Posts = filteredPosts;

            return PartialView("SearchView",apm);
        }

    }
}