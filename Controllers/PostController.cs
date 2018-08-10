using System;
using System.Collections.Generic;
using System.Linq;
using docker_mysql.Models;
using Microsoft.AspNetCore.Mvc;

namespace docker_mysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private MyDbContext _myDbContext = new MyDbContext();

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            return _myDbContext.Post;
        }
        [HttpPost("save-post")]
        public ActionResult<IEnumerable<Post>> SavePost([FromBody]Post post)
        {
            var newPost = new Post();
            newPost = post;
            _myDbContext.Post.Add(newPost);
            _myDbContext.SaveChanges();
            return Ok(newPost);
        }

        [HttpPost("save-blog")]
        public ActionResult<IEnumerable<Blog>> SaveBlog([FromBody]Blog blog)
        {
            var newBlog = new Blog();
            newBlog = blog;
            _myDbContext.Blog.Add(newBlog);
            _myDbContext.SaveChanges();
            return Ok(newBlog);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteData(int id)
        {
            var blog = new Blog { BlogId = id };
            _myDbContext.Blog.Remove(blog);
            _myDbContext.SaveChanges();

        }

        [HttpPut("update-post/{postId}")]
        public ActionResult<IEnumerable<Post>> UpdatePost(int postId, [FromBody]Post post)
        {
            //    context.Students.First<Student>(s => s.StudentId == 1); 
            _myDbContext.Post.Where(o => o.PostId == postId);
            _myDbContext.Update<Post>(post);
            _myDbContext.SaveChanges();
            return Ok(post);
        }
    }
}
