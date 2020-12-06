using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public String Username { get; set; }

        [Required, StringLength(20)]
        public String FirstName { get; set; }

        [Required, StringLength(20)]
        public String Surname { get; set; }
        
        [Required]
        public String  Password { get; set; }

        public String  Salt { get; set; }

        [Required, StringLength(35)]
        public String Email { get; set; }


        public virtual  List<Comment> Comments { get; set; }

    }

}