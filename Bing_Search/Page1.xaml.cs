using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using UmengSocialSDK;
using UmengSocialSDK.Net.Request;
using Bing_Search.Core;

namespace Bing_Search
{
    public partial class Page1 : PhoneApplicationPage
    {
        bool IsLoadedFailed = false;

        public Page1()
        {
            InitializeComponent();
            this.wb.Navigating += (sender, args) =>
            {
                this.txt.Text = args.Uri.AbsoluteUri;
                this.Loader.IsIndeterminate = true;
            };
            this.wb.Navigated += (sender, args) =>
            {
                this.Loader.IsIndeterminate = false;
            };
            this.wb.NavigationFailed += (sender, args) =>
            {
                this.Loader.IsIndeterminate = false;
                IsLoadedFailed = true;
                this.wb.Navigate(new Uri("/webpage/error.html", UriKind.Relative));
            };
        }

        #region BrowserCore
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            UmengSDK.UmengAnalytics.TrackPageEnd("web_browser");
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UmengSDK.UmengAnalytics.TrackPageStart("web_browser");
            if (NavigationContext.QueryString["web"] == "")
            {
                NavigationService.GoBack();
            }
            else
            {
                this.data.Text = NavigationContext.QueryString["data"];
                webdisplay();
            }
        }
        private void webdisplay()
        {
            string wd = NavigationContext.QueryString["web"];
            this.wb.Navigate(new Uri(wd, UriKind.Absolute));
        }
        #endregion
        #region Function
        #region NavigationFunction
        private void back_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (IsLoadedFailed == true)
            { MessageBox.Show("请先检查网络连接"); }
            else
            {
                wb.InvokeScript("eval", "history.go(-1)");
            }
        }
        private void next_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (IsLoadedFailed == true)
            { MessageBox.Show("请先检查网络连接"); }
            else
            {
                wb.InvokeScript("eval", "history.go(1)");
            }
        }
        private void refresh_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (IsLoadedFailed == true)
            { MessageBox.Show("请先检查网络连接"); }
            else
            {
                wb.InvokeScript("eval", "history.go()");
            }
        }
        #endregion
        #region SwitchSearchEngineFunction
        private void ApplicationBarMenuItem_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.change_show.Begin();
            this.popus.IsOpen = false;
            this.popa.IsOpen = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.change_show_Copy1.Begin();
            string MyUri = "";
            if (this.bing.IsSelected == true)
            {
                SearchCore.InternalSearchTask(data.Text);
            }
            else if (this.aps.IsSelected == true)
            {
                SearchCore.AppSearchTask(data.Text);
            }
            else
            {
                if (this.bd.IsSelected == true)
                {
                    MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + data.Text;
                }
                else if (this.pb.IsSelected == true)
                {
                    MyUri = "http://thepiratebay.se/s/?q=" + data.Text + "&page=0&orderby=99";
                }
                else if (this.g.IsSelected == true)
                {
                    MyUri = "http://www.google.com.hk/search?q=" + data.Text + "&newwindow=1&safe=off";
                }
                else if (this.by.IsSelected == true)
                {
                    MyUri = "http://www.5p44.com/?q=" + data.Text;
                }
                else if (this.yh.IsSelected == true)
                {
                    MyUri = "https://hk.search.yahoo.com/search?p=" + data.Text;
                }
                else if (this.sg.IsSelected == true)
                {
                    MyUri = "http://www.sogou.com/web?query=" + data.Text;
                }
                else if (this.ts.IsSelected == true)
                {
                    MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + data.Text + "&go=Go";
                }
                else if (this.ka.IsSelected == true)
                {
                    MyUri = "http://kickass.to/usearch/" + data.Text;
                }
                else if (this.btd.IsSelected == true)
                {
                    MyUri = "http://btdigg.org/search?q=" + data.Text;
                }
                else if (this.ip.IsSelected == true)
                {
                    MyUri = "http://www.iconpng.com/search/tag=" + data.Text;
                }

                else if (this.av.IsSelected == true)
                {
                    MyUri = "http://www.avdb.in/search/" + data.Text;
                }
                else if (this.ut.IsSelected == true)
                {
                    MyUri = "http://ulozto.net/hledej?q=" + data.Text;
                }
                this.wb.Navigate(new Uri(MyUri, UriKind.Absolute));
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.change_show_Copy1.Begin();
        }
        #endregion
        #region ToolbarControl
        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.popus.IsOpen = false;
            this.popa.IsOpen = true;
        }
        private void tool_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.popus.IsOpen = true;
            this.popa.IsOpen = false;
        }
        #endregion
        #region ShareControl
        private void Share_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {

            ShareData shareData = new ShareData();

            shareData.Content = "我通过爱搜索搜“" + this.data.Text + "”，搜到了些好玩的东西，大伙儿一起来看看！";
            shareData.Url.Link = this.txt.Text;
            shareData.Url.Type = UrlType.Video;
            shareData.Url.Author = "PW Studio";
            shareData.Url.Title = "爱搜索";


            WxPlatformInfo wxInfo = new WxPlatformInfo()
            {
                AppId = "wx5ebe851b58f090d4",
                Type = DataType.Text,
                Title = "爱搜索",
                Description = "分享的地址：" + this.txt.Text
            };
            var dic = new Dictionary<SharePlatform, PlatformInfo>();
            dic.Add(SharePlatform.Wechat, wxInfo);
            dic.Add(SharePlatform.Wxcircle, wxInfo);
            ShareOption option = new ShareOption();
            option.ShareCompleted = args =>
            {
                if (args.StatusCode == UmengSocialSDK.UmEventArgs.Status.Successed)
                {
                    MessageBox.Show("分享成功");
                }
                else
                {
                    MessageBox.Show("分享失败");
                }
            };

            UmengSocial.Share("53d37a3c56240b2b9e0a3288", shareData, dic, this, option);

        }
        private void Onenote_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string a = "关键词：" + this.data.Text + "网址：" + this.txt.Text;
            NavigationService.Navigate(new Uri("/OneNoteShare.xaml?readytoshare=" + a, UriKind.Relative));
        }
        private void Open_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {

            WebBrowserTask w = new WebBrowserTask();
            w.Uri = new Uri(this.txt.Text);
            w.Show();
        }
        #endregion
        #endregion
    }
}