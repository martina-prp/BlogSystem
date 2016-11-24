using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSystem.Controllers
{
    public class PostController : BaseController
    {
        public ActionResult Index()
        {
            ICollection<PostViewModel> posts = this.Context.Posts.OrderByDescending(p => p.DateCreated).
                Select(p => new PostViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Content = p.Content,
                DateCreated = p.DateCreated,
                userName = p.User.UserName

            }).ToList();
 
            return View(posts);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(PostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            var currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == HttpContext.User.Identity.Name);
            Post post = new Post()
            {
                Name = postViewModel.Name,
                Content = postViewModel.Content,
                DateCreated = DateTime.Now,
                User = currentUser,
            };

            this.Context.Posts.Add(post);
            this.Context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var post = this.Context.Posts.FirstOrDefault(p => p.Id == id);
            var postView = new PostViewModel()
            {
                Id = post.Id,
                Name = post.Name,
                Content = post.Content,
                DateCreated = post.DateCreated,
                userName = post.User.UserName
            };

            return View(postView);
        }

        [HttpPost]
        public ActionResult Update(int id, PostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Update");
            }

            var post = this.Context.Posts.FirstOrDefault(p => p.Id == id);
            post.Name = postViewModel.Name;
            post.Content = postViewModel.Content;
            post.User = this.Context.Users.FirstOrDefault(user => user.UserName == postViewModel.userName);
            this.Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteConfirmation(int id)
        {
            var post = this.Context.Posts.FirstOrDefault(p => p.Id == id);
            var postView = new PostViewModel
            {
                Id = post.Id,
                Name = post.Name,
                Content = post.Content,
                DateCreated = post.DateCreated,
                userName = post.User.UserName
            };

            return View(postView);
        }

        public ActionResult Delete(int id)
        {
            var post = this.Context.Posts.FirstOrDefault(p => p.Id == id);
            this.Context.Posts.Remove(post);
            this.Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = this.Context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }

            ICollection<CommentViewModels> commentView = this.Context.Comments.Select(c => new CommentViewModels()
            {
                Id = c.Id,
                Message = c.Message,
                PostedDate = c.PostedDate,
                userName = c.User.UserName,
                PostId = c.Post.Id,

            }).Where(c => c.PostId == id).ToList();
            PostViewModel postView = new PostViewModel()
            {
                Id = post.Id,
                Name = post.Name,
                Content = post.Content,
                DateCreated = post.DateCreated,
                userName = post.User.UserName,
                Comments = commentView
            };

            return View(postView);
        }
    }
}