using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models.AdminPostViewModel
{
    public class AdminPostViewModel
    {
        public Admin Admin { get; set; }
        public List<Post> Posts { get; set; }
        

    }
}