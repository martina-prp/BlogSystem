using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Comment
    {
        public int Id
        {
            get;
            set;
        }

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

        public virtual ApplicationUser User
        {
            get;
            set;
        }

        public virtual Post Post
        {
            get;
            set;
        }
    }
}
