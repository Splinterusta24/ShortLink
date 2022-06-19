using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShortLink.Models
{
    public class Link
    {

        public string LongLink { get; set; }
        public string ShortLink { get; set; }

        public void Ekle()
        {
            SqlConnection conn = new SqlConnection("Server = DESKTOP-63E5VH2; Database = LinkShortening; Trusted_Connection = True;");

            SqlCommand cmd = new SqlCommand("Insert into Short (LongLink,ShortLink) values (@longlink,@shortlink)", conn);
            cmd.Parameters.AddWithValue("@longlink", LongLink);
            cmd.Parameters.AddWithValue("@shortlink", ShortLink);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


        }

    }
}