using ShortLink.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortLink.Models
{
    public static class GenerateShortLink
    {
        public static string Generate()
        {
            string shortLink = "";
            //shortLink = DateTime.Now.ToString("d/MM/yyyy/hh/HH/mm/ss");
            shortLink = DateTime.Now.TarihiCevir();
            //shortLink = shortLink.Replace(".", ""); /*string.Empty == "" */
            shortLink = shortLink.Temizle();
            return shortLink;
        }
       

        

    }
}