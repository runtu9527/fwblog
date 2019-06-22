using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fwblog.Model
{
    public class Blog
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public DateTime CreatTime { get; set; } = DateTime.Now;
    }

    public class BlogCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }

}
