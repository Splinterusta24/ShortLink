using ShortLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortLink.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    Link link = new Link();

        //    return View(link);
        //}
        public ActionResult Index()
        {
            Link link = new Link();

            return View(link.TumLinkleriGetir());
        }
        [HttpPost]
        public JsonResult LinkKisalt(string uzunLink)
        {
            string kisaLink = GenerateShortLink.Generate();
            Link link = new Link();
            link.ShortLink = kisaLink;
            link.LongLink = uzunLink;
            link.Ekle();
           
            
           
            return Json(kisaLink);


        }
    }
}