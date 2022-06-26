using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortLink.Models
{
    public class DController : Controller
    {
        // GET: D

        //action result ın requestine string değişken yazılırsa, browserdan gelen query içiine yükler. Parametre gereklidir.
        public ActionResult In(string I)
        {
            //Request.ClientCertificate - Requestle tüm istekleri görebilirsin
            Link link = new Link();
            link.ShortLink = I;
            string directLink = link.UzunLinkGetir();

            //string param = Request.QueryString["I"].ToString();

            Response.Redirect(directLink);
            return View();
        }
    }
}