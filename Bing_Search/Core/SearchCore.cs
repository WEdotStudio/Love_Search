using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Windows.Navigation;

namespace Bing_Search.Core
{
    public class SearchCore:Bing_Search.OldMainPage
    {
        public static void InternalSearchTask(string data){
            SearchTask s = new SearchTask();
            s.SearchQuery = data;
            s.Show();
        }
        public async static void AppSearchTask(string data)
        {
            string a = "zune:search?keyword=" + data + "&contenttype=app";
            await Windows.System.Launcher.LaunchUriAsync(new Uri(a));
        }
        public static void NewTabView(string MyUri)
        {
            WebBrowserTask w = new WebBrowserTask();
            w.Uri = new Uri(MyUri);
            w.Show();
        }
        
    }
}
