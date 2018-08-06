using System;
using System.Collections.Generic;

namespace docker_mysql.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Post = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Post { get; set; }
    }
}
