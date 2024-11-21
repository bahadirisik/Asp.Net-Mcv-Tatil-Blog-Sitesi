using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSitesi.Models.Siniflar;

namespace TatilSitesi.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context context = new Context();
        BlogYorum blogYorum = new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar = context.Blogs.ToList();
            blogYorum.Deger1 = context.Blogs.ToList();
            blogYorum.Deger3 = context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(blogYorum);
        }

        public ActionResult BlogDetay(int id)
		{
            //var blogs = context.Blogs.Where(x => x.ID == id).ToList();
            blogYorum.Deger1 = context.Blogs.Where(x => x.ID == id).ToList();
            blogYorum.Deger2 = context.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(blogYorum);
		}

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
		{
            context.Yorumlars.Add(y);
            context.SaveChanges();
            return PartialView();
		}
    }
}