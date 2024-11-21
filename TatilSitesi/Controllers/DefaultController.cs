using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSitesi.Models.Siniflar;

namespace TatilSitesi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context context = new Context();
        List<Blog> bloglar = new List<Blog>();
        public ActionResult Index()
        {
            bloglar = context.Blogs.Take(4).ToList();
            return View(bloglar);
        }

        public ActionResult About()
		{
            return View();
		}

        public PartialViewResult Partial1()
		{
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
		}

        public PartialViewResult Partial2()
        {
            var degerler = context.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial3()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial4()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(6).ToList();
            return PartialView(degerler);
        }
    }
}