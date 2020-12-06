using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models.PostCommentViewModel
{
    public class PostCommentViewModel
    {
        public Post post { get; set; }
        public List<Comment> comments { get; set; }
    }
}