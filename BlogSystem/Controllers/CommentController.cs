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

        /*[HttpGet]
        [Authorize]
        public ActionResult Create(int id)
        {
            return RedirectToAction(actionName: "_Create", controllerName: "Comment", routeValues: new { id });
        }*/

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
            commentViewModel.userName = currentUser.UserName;
            commentViewModel.PostedDate = comment.PostedDate;

            this.Context.Comments.Add(comment);
            this.Context.SaveChanges();

            /*ICollection<CommentViewModels> postComments = this.Context.Comments.Where(c => c.Post.Id == id).Select
                (c => new CommentViewModels()
                {
                    Message = c.Message,
                    PostedDate = c.PostedDate,
                    userName = c.User.UserName,
                    PostId = c.Post.Id
                }).ToList();*/

            return PartialView("_Create", commentViewModel);
            //return RedirectToAction("Details", "Post", new { id = id });
        }

        /*public PartialViewResult _Create(int id)
        {
            CommentViewModels commentVM = new CommentViewModels() { PostId = id };
            return PartialView("_Create", commentVM);
        }*/
    }
}