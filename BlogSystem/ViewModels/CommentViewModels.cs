using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.ViewModels
{
    public class CommentViewModels
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string Message
        {
            get;
            set;
        }

        public DateTime PostedDate
        {
            get;
            set;
        }

        public string userName
        {
            get;
            set;
        }

        public int PostId
        {
            get;
            set;
        }
    }
}