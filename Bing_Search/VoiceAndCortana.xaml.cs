using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using Bing_Search.Core;

namespace Bing_Search
{
    public partial class VoiceAndCortana : PhoneApplicationPage
    {
        public VoiceAndCortana()
        {
            InitializeComponent();
        }
        public void DefaultIETask(string keyword)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            string MyUri = "";
            
            if (settings["defaultse"] == "1")
            {
                SearchCore.InternalSearchTask(keyword);
            }
            else if (settings["defaultse"] == "9")
            {
                SearchCore.AppSearchTask(keyword);
            }
            else
            {
                if (settings["defaultse"] == "2")
                {
                    MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + keyword;
                }
                else if (settings["defaultse"] == "3")
                {
                    MyUri = "http://thepiratebay.se/s/?q=" + keyword + "&page=0&orderby=99";
                }
                else if (settings["defaultse"] == "4")
                {
                    MyUri = "http://www.google.com.hk/search?q=" + keyword + "&newwindow=1&safe=off";
                }
                else if (settings["defaultse"] == "5")
                {
                    MyUri = "http://www.5p44.com/?q=" + keyword;
                }
                else if (settings["defaultse"] == "6")
                {
                    MyUri = "https://hk.search.yahoo.com/search?p=" + keyword;
                }
                else if (settings["defaultse"] == "7")
                {
                    MyUri = "http://www.sogou.com/web?query=" + keyword;
                }
                else if (settings["defaultse"] == "8")
                {
                    MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + keyword + "&go=Go";
                }
                else if (settings["defaultse"] == "10")
                {
                    MyUri = "http://kickass.to/usearch/" + keyword;
                }
                else if (settings["defaultse"] == "11")
                {
                    MyUri = "http://btdigg.org/search?q=" + keyword;
                }
                else if (settings["defaultse"] == "12")
                {
                    MyUri = "http://www.iconpng.com/search/tag=" + keyword;
                }

                else if (settings["defaultse"] == "13")
                {
                    MyUri = "http://www.avdb.in/search/" + keyword;
                }
                else if (settings["defaultse"] == "14")
                {
                    MyUri = "http://ulozto.net/hledej?q=" + keyword;
                }
                SearchCore.NewTabView(MyUri);
            }
        }
        public void DefaultInternalTask(string keyword)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            string MyUri = "";
            
            if (settings["defaultse"] == "1")
            {
                SearchCore.InternalSearchTask(keyword);
            }
            else if (settings["defaultse"] == "9")
            {
                SearchCore.AppSearchTask(keyword);
            }
            else
            {
                if (settings["defaultse"] == "2")
                {
                    MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + keyword;
                }
                else if (settings["defaultse"] == "3")
                {
                    MyUri = "http://thepiratebay.se/s/?q=" + keyword + "&page=0&orderby=99";
                }
                else if (settings["defaultse"] == "4")
                {
                    MyUri = "http://www.google.com.hk/search?q=" + keyword + "&newwindow=1&safe=off";
                }
                else if (settings["defaultse"] == "5")
                {
                    MyUri = "http://www.5p44.com/?q=" + keyword;
                }
                else if (settings["defaultse"] == "6")
                {
                    MyUri = "https://hk.search.yahoo.com/search?p=" + keyword;
                }
                else if (settings["defaultse"] == "7")
                {
                    MyUri = "http://www.sogou.com/web?query=" + keyword;
                }
                else if (settings["defaultse"] == "8")
                {
                    MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + keyword + "&go=Go";
                }
                else if (settings["defaultse"] == "10")
                {
                    MyUri = "http://kickass.to/usearch/" + keyword;
                }
                else if (settings["defaultse"] == "11")
                {
                    MyUri = "http://btdigg.org/search?q=" + keyword;
                }
                else if (settings["defaultse"] == "12")
                {
                    MyUri = "http://www.iconpng.com/search/tag=" + keyword;
                }

                else if (settings["defaultse"] == "13")
                {
                    MyUri = "http://www.avdb.in/search/" + keyword;
                }
                else if (settings["defaultse"] == "14")
                {
                    MyUri = "http://ulozto.net/hledej?q=" + keyword;
                }
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keyword, UriKind.Relative));
            }
        }
        protected async override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == System.Windows.Navigation.NavigationMode.New)
            {
                if (NavigationContext.QueryString.ContainsKey("voiceCommandName"))
                {
                    string voiceCommandName = NavigationContext.QueryString["voiceCommandName"];
                    switch (voiceCommandName)
                    {
                        case "DSearch":
                            string keyword = NavigationContext.QueryString["keywords"];
                            if (IsolatedStorageSettings.ApplicationSettings.Contains("Both"))
                            {
                                if (IsolatedStorageSettings.ApplicationSettings.Contains("IE"))
                                {
                                    DefaultIETask(keyword);
                                }
                                else
                                {
                                    DefaultInternalTask(keyword);
                                }
                            }
                            else if (IsolatedStorageSettings.ApplicationSettings.Contains("Style"))
                            {
                                if (IsolatedStorageSettings.ApplicationSettings.Contains("IE"))
                                {
                                    DefaultIETask(keyword);
                                }
                                else
                                {
                                    DefaultInternalTask(keyword);
                                }
                            }
                            break;
                        case "Search":
                            string keywords = NavigationContext.QueryString["keywords"];
                            string view = NavigationContext.QueryString["engines"];
                            string MyUri = "";
                            if (view.Contains("百度"))
                            {
                                MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + keywords;
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("海盗湾"))
                            {
                                MyUri = "http://thepiratebay.se/s/?q=" + keywords + "&page=0&orderby=99";
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("谷歌"))
                            {
                                MyUri = "http://www.google.com.hk/search?q=" + keywords + "&newwindow=1&safe=off";
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("百度云资源"))
                            {
                                MyUri = "http://www.5p44.com/?q=" + keywords;
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("雅虎香港"))
                            {
                                MyUri = "https://hk.search.yahoo.com/search?p=" + keywords;
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("搜狗"))
                            {
                                MyUri = "http://www.sogou.com/web?query=" + keywords;
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("维基百科"))
                            {
                                MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + keywords + "&go=Go";
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("应用商店"))
                            {
                                string a = "zune:search?keyword=" + keywords + "&contenttype=app";
                                await Windows.System.Launcher.LaunchUriAsync(new Uri(a));
                            }
                            else if (view.Contains("kickass"))
                            {
                                MyUri = "http://kickass.to/usearch/" + keywords;
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("btdigg"))
                            {
                                MyUri = "http://btdigg.org/search?info_hash=&q=" + keywords;
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("iconpng"))
                            {
                                MyUri = "http://www.iconpng.com/search/tag=" + keywords;
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }

                            else if (view.Contains("avdb"))
                            {
                                MyUri = "http://www.avdb.in/search/" + keywords;
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            else if (view.Contains("Ulož"))
                            {
                                MyUri = "http://ulozto.net/hledej?q=" + keywords;
                                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + keywords, UriKind.Relative));
                            }
                            break;
                        case "vpn":
                            string vpn1 = "122.132.104.224";
                            string vpn2 = "41.138.187.104";
                           
                            string vpnvaule = "";
                            Random rad = new Random();
                            int value = rad.Next(1,2);
                            switch (value)
                            {
                                case 1:
                                    vpnvaule = vpn1;
                                    break;
                                case 2:
                                    vpnvaule = vpn2;
                                    break;
                                //case 3:
                                 //   vpnvaule = vpn3;
                                 //   break;
                                //case 4:
                                //    vpnvaule = vpn4;
                                 //   break;
                                //case 5:
                                //    vpnvaule = vpn5;
                                 //   break;
                            }
                            Clipboard.SetText(vpnvaule);
                            MessageBox.Show("复制成功！请前往创建VPN");
                            NavigationService.GoBack();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                NavigationService.GoBack();
                }
            }
        }
    }
}