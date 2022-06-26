using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShortLink.Models
{
    public class Link
    {
        public int Id { get; set; }
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

        public int Showme()
        {
            
            SqlConnection conn = new SqlConnection("Server = DESKTOP-63E5VH2; Database = LinkShortening; Trusted_Connection = True;");

            SqlCommand cmd = new SqlCommand("Select*from Short Order by Id desc", conn);
            //cmd.Parameters.AddWithValue("@id", Id);
            conn.Open();
            int x = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return x;
            
        }
        List<string> list = new List<string>();
        public List<string> Kaan()
        {
            list.Add("1.sıra");
            list.Add("2.sıra");
            list.Add("3.sıra");
            list.Add("4.sıra");

            return list;
        }

        public Link UzunLinkGetir()
        {
            SqlConnection conn = new SqlConnection("Server = DESKTOP-63E5VH2; Database = LinkShortening; Trusted_Connection = True;");

            SqlCommand cmd = new SqlCommand("Select * from Short where ShortLink= @shortlink ", conn);
            cmd.Parameters.AddWithValue("@shortlink", ShortLink);
            DataTable dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            Link link = new Link();

            if (dt.Rows.Count>0)
            {

                link.LongLink =  dt.Rows[0]["LongLink"].ToString();
                link.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                return link;
            }
            else
            {
                return new Link();
            }
        }
        public List<Link> TumLinkleriGetir()
        {
            SqlConnection conn = new SqlConnection("Server = DESKTOP-63E5VH2; Database = LinkShortening; Trusted_Connection = True;");

            SqlCommand cmd = new SqlCommand("Select * from Short", conn);
            DataTable dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            List<Link> linkler = new List<Link>();
            foreach (DataRow satir in dt.Rows)
            {
                linkler.Add(new Link
                {
                    LongLink = satir["LongLink"].ToString(),
                    ShortLink = satir["ShortLink"].ToString()

                } );
            }
            return linkler;

        }

    }
}