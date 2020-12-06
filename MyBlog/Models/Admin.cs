using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    [Table("Admins")]
    public class Admin
    {   
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30), Required]
        public String Name { get; set; }

        [StringLength(30), Required]
        public String  Surname { get; set; }

        [StringLength(30), Required]
        public String  Username { get; set; }

        [Required]
        public String Password { get; set; }

        
        public String Salt { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}