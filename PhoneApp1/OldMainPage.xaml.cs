using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Bing_Search.Resources;
using Microsoft.Phone.Tasks;
using Bing_Search.Entity;
using System.Windows.Input;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.Windows.Media.Imaging;
using System.IO;
using Microsoft.Phone.Net.NetworkInformation;

namespace Bing_Search
{
    public partial class MainPage : PhoneApplicationPage
    {
        /// <summary>
        /// 当前显示的Bing图片
        /// </summary>
        protected Entity.BingImage _currentBingImg;

        /// <summary>
        /// 当前显示图片的Index值
        /// </summary>
        protected int _currentImgIndex;

        /// <summary>
        /// WebBrowserTask对象
        /// </summary>
        protected WebBrowserTask _browserTask;

        /// <summary>
        /// PhotoChooserTask对象
        /// </summary>
        protected PhotoChooserTask _photoChooserTask;

        bool IsTap = false;
        
        /// </summary>
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            InitMenber();
            GetImage();
            this.text.KeyUp += new KeyEventHandler(textBox_KeyUp);
            
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("Both"))
                {
                    if (IsolatedStorageSettings.ApplicationSettings.Contains("IE"))
                    {
                        if (text.Text == "")
                        {
                            return;
                        }
                        if (this.bing.IsSelected == true)
                        {
                            SearchTask s = new SearchTask();
                            s.SearchQuery = text.Text;
                            s.Show();
                        }
                        else if (this.bd.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.pb.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.g.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.by.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.5p44.com/?q=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.yh.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.sg.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.sogou.com/web?query=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.ts.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.aps.IsSelected == true)
                        {
                            string a = "zune:search?keyword=" + text.Text + "&contenttype=app";
                            Windows.System.Launcher.LaunchUriAsync(new Uri(a));
                        }
                        else if (this.ka.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://kickass.to/usearch/" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.btd.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://btdigg.org/search?q=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.ip.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }

                        else if (this.av.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.avdb.in/search/" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                    }
                    else
                    {
                        if (text.Text == "")
                        {
                            return;
                        }
                        if (this.bing.IsSelected == true)
                        {
                            SearchTask s = new SearchTask();
                            s.SearchQuery = text.Text;
                            s.Show();
                        }
                        else if (this.bd.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.pb.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.g.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.by.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.5p44.com/?q=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.yh.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.sg.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.sogou.com/web?query=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.ts.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.aps.IsSelected == true)
                        {
                            string a = "zune:search?keyword=" + text.Text + "&contenttype=app";
                            Windows.System.Launcher.LaunchUriAsync(new Uri(a));
                        }
                        else if (this.ka.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://kickass.to/usearch/" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.btd.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://btdigg.org/search?q=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.ip.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }

                        else if (this.av.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.avdb.in/search/" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }

                    }
                }
                else if (IsolatedStorageSettings.ApplicationSettings.Contains("Style"))
                {
                    if (IsolatedStorageSettings.ApplicationSettings.Contains("IE"))
                    {
                        if (text.Text == "")
                        {
                            return;
                        }
                        if (this.bing.IsSelected == true)
                        {
                            SearchTask s = new SearchTask();
                            s.SearchQuery = text.Text;
                            s.Show();
                        }
                        else if (this.bd.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.pb.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.g.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.by.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.5p44.com/?q=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.yh.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.sg.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.sogou.com/web?query=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.ts.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.aps.IsSelected == true)
                        {
                            string a = "zune:search?keyword=" + text.Text + "&contenttype=app";
                            Windows.System.Launcher.LaunchUriAsync(new Uri(a));
                        }
                        else if (this.ka.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://kickass.to/usearch/" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.btd.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://btdigg.org/search?q=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                        else if (this.ip.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                      
                        else if (this.av.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.avdb.in/search/" + text.Text;
                            WebBrowserTask w = new WebBrowserTask();
                            w.Uri = new Uri(MyUri);
                            w.Show();
                        }
                    }
                    else
                    {
                        if (text.Text == "")
                        {
                            return;
                        }
                        if (this.bing.IsSelected == true)
                        {
                            SearchTask s = new SearchTask();
                            s.SearchQuery = text.Text;
                            s.Show();
                        }
                        else if (this.bd.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.pb.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.g.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.by.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.5p44.com/?q=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.yh.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.sg.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.sogou.com/web?query=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.ts.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.aps.IsSelected == true)
                        {
                            string a = "zune:search?keyword=" + text.Text + "&contenttype=app";
                            Windows.System.Launcher.LaunchUriAsync(new Uri(a));
                        }
                        else if (this.ka.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://kickass.to/usearch/" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.btd.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://btdigg.org/search?q=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }
                        else if (this.ip.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative)) ;
                        }
                       
                        else if (this.av.IsSelected == true)
                        {
                            string MyUri = "";
                            MyUri = "http://www.avdb.in/search/" + text.Text;
                            NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                        }

                    }
                }
                else
                {

                    this.Focus();
                    return;
                }


            }
        }

        //private void SettingsShow(object sender, RoutedEventArgs e)
        //{
           // if (IsolatedStorageSettings.ApplicationSettings.Contains("Hide"))
            //{
            //    this.abar.Mode = ApplicationBarMode.Default;
            //}
            //else if(IsolatedStorageSettings.ApplicationSettings.Contains("CheckBox1Setting")) 
            //{
            //    this.abar.Mode=ApplicationBarMode.Minimized;
            //}
            
        //}

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            UmengSDK.UmengAnalytics.TrackPageEnd("main_page");
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UmengSDK.UmengAnalytics.TrackPageStart("main_page");
           
            if (IsolatedStorageSettings.ApplicationSettings.Contains("Style"))
            {
                this.sb.Opacity = 0;
                this.search.Opacity = 0;
            }
            else
            {
                this.search.Opacity = 0.5;
                this.sb.Opacity = 1;
            }
            if (IsolatedStorageSettings.ApplicationSettings.Contains("firstrun"))
            {
                return;

            }
            else
            {
                IsolatedStorageSettings.ApplicationSettings["firstrun"] = "1";
                this.NavigationService.Navigate(new Uri("/firstrun.xaml", UriKind.Relative));

            }
        }
        
        /// <summary>
        /// 初始化页面的变量
        /// </summary>
        private void InitMenber()
        {
            _currentBingImg = null;
            _currentImgIndex = BingImageCollection.MIN_INDEX;

            _browserTask = new WebBrowserTask();
            _photoChooserTask = new PhotoChooserTask();
 
        }


        


        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="showWhenFinish">获取成功后是否显示到页面上</param>
        private void GetImage(bool showWhenFinish = true)
        {
            this.image.Visibility = System.Windows.Visibility.Visible;

            // 初始化异步获取图片的回调“函数”
            var callBack = new Action<Entity.BingImage>((img) =>
            {
                _currentBingImg = img;

                if (showWhenFinish)
                {
                    // 显示图片
                    ShowImg();
                }
            });

            try
            {
                Entity.BingImage.GetBimgImage(_currentImgIndex, callBack);
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
                    this.txtCopyrightTitle.DataContext = _currentBingImg;
                    this.txtCopyrightContent.DataContext = _currentBingImg;
                });
                InvokeAction(showImgAction);
                

            }
            else
            {
                throw new Exception("无法获取到图片，请确认网络是否链接正常！");
            }

        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void icbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveImg();
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        private static void Alert(string msg)
        {
            MessageBox.Show(msg, "程序提示", MessageBoxButton.OK);
        }
        /// <summary>
        /// 保存图片到媒体库
        /// </summary>
        private void SaveImg()
        {


            var imgUri = new Uri(_currentBingImg.Url, UriKind.Absolute);
            var webClient = new WebClient();
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler((webClientSender, webClientEventArgs) =>
            {
                if (webClientEventArgs.Error == null && webClientEventArgs.Result != null)
                {
                    var stream = webClientEventArgs.Result;
                    try
                    {
                        var fileSaveName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                        MediaLibrary mediaLibrary = new MediaLibrary();
                        Picture pic = mediaLibrary.SavePicture(fileSaveName, stream);

                        stream.Close();

                        if (Confirm("保存成功，是否转到媒体库？"))
                        {
                            ShowImgLib();
                        }
                    }
                    catch
                    {
                        throw new Exception("保存失败！");
                    }
                }
                else
                {
                    throw new Exception("获取图片不到！");
                }
            });
            webClient.OpenReadAsync(imgUri);
        }
        /// <summary>
        /// 显示图片媒体库
        /// </summary>
        private void ShowImgLib()
        {
            try
            {
                _photoChooserTask.Show();
            }
            catch
            {
                throw new Exception("打开图片媒体库失败！");
            }
        }
        /// <summary>
        /// 显示确认提示
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        private static bool Confirm(string msg)
        {
            return MessageBox.Show(msg, "程序提示", MessageBoxButton.OKCancel) == MessageBoxResult.OK;
        }
        private void InvokeAction(Action act)
        {
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(act);
        }
        private void lbHotSpot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var o = e.OriginalSource;
        }
        private void icbtnPre_Click(object sender, EventArgs e)
        {
            if (_currentImgIndex < BingImageCollection.MAX_INDEX)
            {
                try
                {
                    _currentImgIndex += 1;
                    GetImage();
                }
                catch (Exception ex)
                {
                    Alert(ex.Message);
                }
            }
            else
            {
                Alert("无法获取更早前的图片了！");
            }
        }

        /// <summary>
        /// 下一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void icbtnNext_Click(object sender, EventArgs e)
        {
            if (_currentImgIndex > BingImageCollection.MIN_INDEX)
            {
                try
                {
                    _currentImgIndex -= 1;
                    GetImage();
                }
                catch (Exception ex)
                {
                    Alert(ex.Message);
                }
            }
            else
            {
                Alert("已经是最新的图片了！");
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
        }
        private void ApplicationBarMenuItem_Clicka(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SettingsWithoutConfirmation.xaml", UriKind.Relative));
        }


        private void TapShow(object sender,System.Windows.Input.GestureEventArgs e)
        {
            if (IsTap == false)
            {
                this.Tap_in.Begin();
                this.LayoutRoot.Background.Opacity=0;
                this.image.Opacity = 0.5;
                this.txtCopyrightContent.Opacity = 0.5;
                this.txtCopyrightTitle.Opacity = 0.5;
                IsTap = true;
            }
        }
        

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (IsTap == true)
            {   e.Cancel = true;
                this.Tap_Copy1.Begin();
                this.LayoutRoot.Background.Opacity = 1;
                this.image.Opacity = 1;
                this.txtCopyrightContent.Opacity = 1;
                this.txtCopyrightTitle.Opacity = 1;
                IsTap = false;
            }
            else { e.Cancel = false; }
        }

        private void a_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("Both"))
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("IE"))
                {
                    if (text.Text == "")
                    {
                        return;
                    }
                    if (this.bing.IsSelected == true)
                    {
                        SearchTask s = new SearchTask();
                        s.SearchQuery = text.Text;
                        s.Show();
                    }
                    else if (this.bd.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + text.Text;
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                    else if (this.pb.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                    else if (this.g.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                    else if (this.by.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.5p44.com/?q=" + text.Text;
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                    else if (this.yh.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                    else if (this.sg.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.sogou.com/web?query=" + text.Text;
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                    else if (this.ts.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                    else if (this.aps.IsSelected == true)
                    {
                        string a = "zune:search?keyword=" + text.Text + "&contenttype=app";
                        Windows.System.Launcher.LaunchUriAsync(new Uri(a));
                    }
                    else if (this.ka.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://kickass.to/usearch/" + text.Text;
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                    else if (this.btd.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://btdigg.org/search?q=" + text.Text;
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                    else if (this.ip.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }

                    else if (this.av.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.avdb.in/search/" + text.Text;
                        WebBrowserTask w = new WebBrowserTask();
                        w.Uri = new Uri(MyUri);
                        w.Show();
                    }
                }
                else
                {
                    if (text.Text == "")
                    {
                        return;
                    }
                    if (this.bing.IsSelected == true)
                    {
                        SearchTask s = new SearchTask();
                        s.SearchQuery = text.Text;
                        s.Show();
                    }
                    else if (this.bd.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + text.Text;
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }
                    else if (this.pb.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }
                    else if (this.g.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }
                    else if (this.by.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.5p44.com/?q=" + text.Text;
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }
                    else if (this.yh.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }
                    else if (this.sg.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.sogou.com/web?query=" + text.Text;
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }
                    else if (this.ts.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }
                    else if (this.aps.IsSelected == true)
                    {
                        string a = "zune:search?keyword=" + text.Text + "&contenttype=app";
                        Windows.System.Launcher.LaunchUriAsync(new Uri(a));
                    }
                    else if (this.ka.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://kickass.to/usearch/" + text.Text;
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }
                    else if (this.btd.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://btdigg.org/search?q=" + text.Text;
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }
                    else if (this.ip.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }

                    else if (this.av.IsSelected == true)
                    {
                        string MyUri = "";
                        MyUri = "http://www.avdb.in/search/" + text.Text;
                        NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
                    }

                }
            }
            else if (IsolatedStorageSettings.ApplicationSettings.Contains("Style"))
            {
                MessageBox.Show("回车就可以了哦！");
                return;
            }
            else { 
            if(IsolatedStorageSettings.ApplicationSettings.Contains("IE"))
            {
                if (text.Text == "")
                {
                    return;
                }
                if (this.bing.IsSelected == true)
                {
                    SearchTask s = new SearchTask();
                    s.SearchQuery = text.Text;
                    s.Show();
                }
                else if (this.bd.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + text.Text;
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
                else if (this.pb.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
                else if (this.g.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
                else if (this.by.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://www.5p44.com/?q=" + text.Text;
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
                else if (this.yh.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
                else if (this.sg.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://www.sogou.com/web?query=" + text.Text;
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
                else if (this.ts.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
                else if (this.aps.IsSelected == true)
                {
                    string a = "zune:search?keyword=" + text.Text + "&contenttype=app";
                    Windows.System.Launcher.LaunchUriAsync(new Uri(a));
                }
                else if (this.ka.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://kickass.to/usearch/" + text.Text;
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
                else if (this.btd.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://btdigg.org/search?q=" + text.Text;
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
                else if (this.ip.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }
               
                else if (this.av.IsSelected == true)
                {
                    string MyUri = "";
                    MyUri = "http://www.avdb.in/search/" + text.Text;
                    WebBrowserTask w = new WebBrowserTask();
                    w.Uri = new Uri(MyUri);
                    w.Show();
                }

            }
            else { 
            if (text.Text == "")
            {
                return;
            }
            if (this.bing.IsSelected == true)
            {
                SearchTask s = new SearchTask();
                s.SearchQuery = text.Text;
                s.Show();
            }
            else if (this.bd.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://m.baidu.com/pu=osname@wphone,sz@1321_480/s?word=" + text.Text;
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
            else if (this.pb.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://thepiratebay.se/s/?q=" + text.Text + "&page=0&orderby=99";
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
            else if (this.g.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.google.com.hk/search?q=" + text.Text + "&newwindow=1&safe=off";
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
            else if (this.by.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.5p44.com/?q=" + text.Text;
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
            else if (this.yh.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "https://hk.search.yahoo.com/search?p=" + text.Text;
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
            else if (this.sg.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.sogou.com/web?query=" + text.Text;
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
            else if (this.ts.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://en.wikipedia.org/wiki/Special:Search?search=" + text.Text + "&go=Go";
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
            else if (this.aps.IsSelected == true)
            {
                string a = "zune:search?keyword=" + text.Text + "&contenttype=app";
                Windows.System.Launcher.LaunchUriAsync(new Uri(a));
            }
            else if (this.ka.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://kickass.to/usearch/" + text.Text;
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }else if (this.btd.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://btdigg.org/search?q=" + text.Text;
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
            else if (this.ip.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.iconpng.com/search/tag=" + text.Text;
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
            
            else if (this.av.IsSelected == true)
            {
                string MyUri = "";
                MyUri = "http://www.avdb.in/search/" + text.Text;
                WebBrowserTask w = new WebBrowserTask();
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
           }}

        }

        private void icbtna_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/page4.xaml", UriKind.Relative));
        }

        private void icbtnb_Click(object sender, EventArgs e)
        {
              this.popus.IsOpen = true;
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
          this.popus.IsOpen = false;
        }

        

       
    }
}