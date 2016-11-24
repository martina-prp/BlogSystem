using BlogSystem.Models;
using BlogSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Controllers
{
    public class CommentController : BaseController
    {
        // GET: Comment
        /*public ActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(int id, CommentViewModels commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == HttpContext.User.Identity.Name);
            Post post = this.Context.Posts.FirstOrDefault(p => p.Id == id);
            Comment comment = new Comment()
            {
                Message = commentViewModel.Message,
                PostedDate = DateTime.Now,
                User = currentUser,
                Post = post
            };

            this.Context.Comments.Add(comment);
            this.Context.SaveChanges();

            return RedirectToAction("Details", "Post", new { id = id });
        }
    }
}