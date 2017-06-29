using System;
using System.Collections.Generic;

namespace pgSQL.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public int Blogid { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
