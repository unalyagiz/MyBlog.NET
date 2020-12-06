using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public String Description { get; set; }

        [StringLength(75), Required]
        public String Title { get; set; }

        public String ImgUrl { get; set; }

        public DateTime PublishDate { get; set; }
 

        public virtual Admin Admin { get; set; }
        public virtual List<Comment> Comments { get; set; }


    }
}