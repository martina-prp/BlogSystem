using BlogSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController() : this(new BlogSystemDbContext())
        {

        }

        public BaseController(BlogSystemDbContext context)
        {
            this.Context = context;
        }

        protected BlogSystemDbContext Context
        {
            get;
            set;
        }
    }
}