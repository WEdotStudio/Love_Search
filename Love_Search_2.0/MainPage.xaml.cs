using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Love_Search_2._0.Resources;
using LoveSearchCore.Entity;
using Microsoft.Phone.Tasks;
using LoveSearchCore.Core;

namespace Love_Search_2._0
{
    public partial class MainPage : PhoneApplicationPage
    {
        string MyUri = "";
        protected BingImage _currentBingImg;
        protected int _currentImgIndex;
        protected ProgressIndicator tProgIndicator;
        public MainPage()
        {
            InitializeComponent();
            _currentBingImg = null;
            _currentImgIndex = BingImageCollection.MIN_INDEX;
            GetImage();
        }
        private void GetImage(bool showWhenFinish = true)
        {
            this.image.Visibility = System.Windows.Visibility.Visible;

            var callBack = new Action<BingImage>((img) =>
            {
                _currentBingImg = img;

                if (showWhenFinish)
                {
                    ShowImg();
                }
            });

            try
            {
                BingImage.GetBimgImage(_currentImgIndex, callBack);
            }
            catch
            {
                throw new Exception("无法获取到图片，请确认网络是否链接正常！");
            }
        }
        private void ShowImg()
        {
            if (_currentBingImg != null)
            {
                var showImgAction = new Action(() =>
                {

                    this.image.DataContext = _currentBingImg;
                });
                InvokeAction(showImgAction);


            }
            else
            {
                throw new Exception("无法获取到图片，请确认网络是否链接正常！");
            }

        }
        private void InvokeAction(Action act)
        {
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(act);
        }
        private void Pivot_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void a_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (text.Text == "")
            {
                return;
            }
            if (this.bing.IsSelected == true)
            {
                SearchCore.InternalSearchTask(text.Text);
            }
            else if (this.aps.IsSelected == true)
            {
                SearchCore.AppSearchTask(text.Text);
            }
            else
            {
                if (this.bd.IsSelected == true)
                {
                    MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + text.Text;
                }
                else if (this.pb.IsSelected == true)
                {
                    MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                }
                else if (this.g.IsSelected == true)
                {
                    MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                }
                else if (this.by.IsSelected == true)
                {
                    MyUri = "http://www.5p44.com/?q=" + text.Text;
                }
                else if (this.yh.IsSelected == true)
                {
                    MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                }
                else if (this.sg.IsSelected == true)
                {
                    MyUri = "http://www.sogou.com/web?query=" + text.Text;
                }
                else if (this.ts.IsSelected == true)
                {
                    MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                }
                else if (this.ka.IsSelected == true)
                {
                    MyUri = "http://kickass.to/usearch/" + text.Text;
                }
                else if (this.btd.IsSelected == true)
                {
                    MyUri = "http://btdigg.org/search?q=" + text.Text;
                }
                else if (this.ip.IsSelected == true)
                {
                    MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                }

                else if (this.av.IsSelected == true)
                {
                    MyUri = "http://www.avdb.in/search/" + text.Text;
                }
                else if (this.ut.IsSelected == true)
                {
                    MyUri = "http://ulozto.net/hledej?q=" + text.Text;
                }
                SearchCore.NewTabView(MyUri);
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BingPic.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BarCode.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BarCode.xaml?type=qrcode", UriKind.Relative));
        }




        
    }
}