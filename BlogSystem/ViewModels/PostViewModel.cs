using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            this.Comments = new List<CommentViewModels>();
        }

        public int Id
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }

        [Required]
        public string Content
        {
            get;
            set;
        }

        public DateTime? DateCreated
        {
            get;
            set;
        }

        public string userName
        {
            get;
            set;
        }

        public ICollection<CommentViewModels> Comments
        {
            get;
            set;
        }
    }
}