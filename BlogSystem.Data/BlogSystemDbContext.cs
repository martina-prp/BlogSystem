using BlogSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data
{
    public class BlogSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogSystemDbContext() : base("BlogSystemConnection")
        {
        }

        public IDbSet<Post> Posts
        {
            get;
            set;
        }

        public IDbSet<Comment> Comments
        {
            get;
            set;
        }

        public static BlogSystemDbContext Create()
        {
            return new BlogSystemDbContext();
        }
    }
}
