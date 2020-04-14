using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DailyBlogger.Models;

namespace DailyBlogger.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            IEnumerable<BlogPost> posts = _context.blogPost.ToList<BlogPost>();
            return View(posts);
        }
        
        public IActionResult New()
        {
            BlogPost blogPost = new BlogPost();
            return View(blogPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("blog_title,content,blog_date")] BlogPost blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(blog);
        }

        public IActionResult Details(int blog_id)
        {
            BlogPost blogPost = _context.blogPost.Find(blog_id);
            return View(blogPost);
        }

        public IActionResult Edit(int blog_id)
        {
            BlogPost blogPost = _context.blogPost.Find(blog_id);
            return View(blogPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("blog_title,content,blog_date,blog_id")] BlogPost blog)
        {
            if(ModelState.IsValid)
            {
                _context.Update(blog);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(blog);
        }

        public IActionResult Delete([Bind("blog_id")] int blog_id)
        {
            BlogPost blogPost = _context.blogPost.Find(blog_id);
            _context.Remove(blogPost);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}