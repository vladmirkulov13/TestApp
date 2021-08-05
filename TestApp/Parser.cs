using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Parser
    {
        public HtmlAgilityPack.HtmlWeb Web { get; set; }
        public HtmlAgilityPack.HtmlDocument Doc { get; set; }
        public string Url { get; set; }
        public static string Text { get; set; }
        public static string[] Subs { get; set; }
        public Parser()
        {
            Url = "https :// www . simbirsoft . com /";
            Doc = Web.Load(Url);
        }
        public Parser(string url)
        {
            Url = url;
            Web = new HtmlWeb();
            Doc = Web.Load(url);
            Text = Doc.Text;
        }
        public void GetSeparateHTML()
        {
            char[] separators = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' , '>', '<', '=', '/'};
            string[] sub = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Subs = sub;
        }
    }
}
