using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fwblog.Entity;
using fwblog.Model;
namespace fwblog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        // GET: api/Blog
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Blog/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("getBlog")]
        public ActionResult GetBlog(int category,int blog)
        {
            return new JsonResult(new ApiResponse()
            {
                data = new
                {
                    category=category,
                    blog=blog
                }
            });
        }

        //api/Blog/byPage?page=1
        [HttpGet("byPage")]
        public ActionResult GetPage(int page)
        {
            List<Blog> blogs = new List<Blog>();
            for (int i = 0; i < 100; i++)
            {
                Blog blog = new Blog();
                blog.Id = i;
                blog.Title = "标题" + i;
                blogs.Add(blog);
            }

            List<BlogCategory> categories = new List<BlogCategory>();

            categories.Add(new BlogCategory() { Id = 1, Name = "分类1", Blogs = blogs });
            categories.Add(new BlogCategory() { Id = 2, Name = "分类2", Blogs = blogs });

            return new JsonResult(new ApiResponse() { data = categories });
        }

        // POST: api/Blog
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
