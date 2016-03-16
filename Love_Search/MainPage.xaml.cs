using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Love_Search
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (text.Text == "")
            {
                return;
            }
            
            else if (this.bd.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.baidu.com/s?word=" + text.Text;
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
            }
            else if (this.pb.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }
            else if (this.g.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }
            else if (this.by.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.5p44.com/?q=" + text.Text;
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }
            else if (this.yh.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }
            else if (this.sg.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.sogou.com/web?query=" + text.Text;
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }
            else if (this.ts.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }
            
            else if (this.ka.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://kickass.to/usearch/" + text.Text;
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }
            else if (this.btd.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://btdigg.org/search?q=" + text.Text;
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }
            else if (this.ip.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }

            else if (this.av.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.avdb.in/search/" + text.Text;
                Uri targetUri = new Uri(MyUri);
                webView1.Navigate(targetUri);
                 
            }
        }
    }
}
