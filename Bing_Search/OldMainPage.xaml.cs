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
using Bing_Search.Core;

namespace Bing_Search
{
    public partial class OldMainPage : PhoneApplicationPage
    {
        #region AppConstant
        protected Entity.BingImage _currentBingImg;
        protected int _currentImgIndex;
        protected WebBrowserTask _browserTask;
        protected PhotoChooserTask _photoChooserTask;

        bool IsTap = false;
        bool IsPopOpenAva = true;
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        #endregion

        public OldMainPage()
        {
            InitializeComponent();
            
            if (!IsolatedStorageSettings.ApplicationSettings.Contains("firstrun"))
            {
                IsolatedStorageSettings.ApplicationSettings.Add("CheckBox1Setting", true);
                IsolatedStorageSettings.ApplicationSettings.Add("CheckBox2Setting", true);
                IsolatedStorageSettings.ApplicationSettings.Add("CheckBox3Setting", true);
                IsolatedStorageSettings.ApplicationSettings.Add("CheckBox4Setting", true);
                IsolatedStorageSettings.ApplicationSettings.Add("CheckBox5Setting", false);
            }
            else
            {
                if (DeviceNetworkInformation.IsNetworkAvailable == false)
                {
                    SwitchToOffineMode();
                }
                else if (DeviceNetworkInformation.IsNetworkAvailable == true)
                {

                    if (settings["CheckBox5Setting"].ToString() == "true")
                    {
                        SwitchToOffineMode();
                    }
                    else
                    {
                        GetImage();
                    }
                }
                InitMenber();
                this.text.KeyUp += new KeyEventHandler(textBox_KeyUp);
            }
            
            
        }

        #region MainPageCore
        public void IEtask()
        {
            string MyUri = "";
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
        public void InternalTask()
        {
            string MyUri = "";
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
                NavigationService.Navigate(new Uri("/page1.xaml?web=" + MyUri + "&data=" + text.Text, UriKind.Relative));
            }
        }
        #endregion
        #region SystemReactions
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {

                if (settings["CheckBox3Setting"].ToString() == "false")
                    {
                        if (settings["CheckBox2Setting"].ToString() == "false")
                        {
                            IEtask();
                        }
                        else
                        {
                            InternalTask();
                        }
                    }
                else if (settings["CheckBox3Setting"].ToString() == "true")
                    {
                        if (settings["CheckBox2Setting"].ToString() == "false")
                        {
                            IEtask();
                        }
                        else
                        {
                            InternalTask();
                        }
                    }

                    else
                    {

                        this.Focus();
                        return;
                    }
                

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
                IsPopOpenAva = true;
                IsTap = false;
            }
            else { e.Cancel = false; }
        }
        #endregion
        #region PhoneNavigationService
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            UmengSDK.UmengAnalytics.TrackPageEnd("main_page");  
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UmengSDK.UmengAnalytics.TrackPageStart("main_page");

            if (settings["CheckBox1Setting"].ToString() == "false")
            {
                this.sb.Opacity = 0;
                this.search.Opacity = 0;
            }
            else
            {
                this.search.Opacity = 0.5;
                this.sb.Opacity = 1;
            }
            if (settings["CheckBox4Setting"].ToString() == "false")
            {
                return;
            }
            else
            {
                TaskCore.RandomReview();
            }
            if (IsolatedStorageSettings.ApplicationSettings.Contains("firstrun"))
            {
                return;
            }
            else
            {
                settings["firstrun"] = "1";
                MessageBox.Show("注意！本程序大多数功能会消耗您的流量，建议您在WIFI下使用");
                this.NavigationService.Navigate(new Uri("/firstexperience.xaml", UriKind.Relative));

            }
        }
        #endregion
        #region BingPhotoCore
        private void InitMenber()
        {
            _currentBingImg = null;
            _currentImgIndex = BingImageCollection.MIN_INDEX;

            _browserTask = new WebBrowserTask();
            _photoChooserTask = new PhotoChooserTask();

        }
        private void GetImage(bool showWhenFinish = true)
        {
            this.image.Visibility = System.Windows.Visibility.Visible;

            var callBack = new Action<Entity.BingImage>((img) =>
            {
                _currentBingImg = img;

                if (showWhenFinish)
                {
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
        private void SwitchToOffineMode()
        {
            this.image.Visibility = System.Windows.Visibility.Visible;
            this.offinepop.IsOpen = true;
        }
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

                        if (TaskCore.Confirm("保存成功，是否转到媒体库？"))
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
        private void InvokeAction(Action act)
        {
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(act);
        }
        private void lbHotSpot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var o = e.OriginalSource;
        }
        #endregion
        #region AppReaction
        private void icbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveImg();
            }
            catch (Exception ex)
            {
                TaskCore.Alert(ex.Message);
            }
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
                    TaskCore.Alert(ex.Message);
                }
            }
            else
            {
                TaskCore.Alert("无法获取更早前的图片了！");
            }
        }
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
                    TaskCore.Alert(ex.Message);
                }
            }
            else
            {
                TaskCore.Alert("已经是最新的图片了！");
            }
        }
        private void icbtna_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/page4.xaml", UriKind.Relative));
        }
        private void icbtnb_Click(object sender, EventArgs e)
        {

            if (IsPopOpenAva == false)
            {
                return;
            }
            else 
            {
             if (IsolatedStorageSettings.ApplicationSettings.Contains("bingp"))
            {
                  MessageBox.Show("Bing图片功能已禁用！");
                 return;
            }
            else{
                   this.popus.IsOpen = true;
                  }
                
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
                if (popus.IsOpen == true)
                {
                    popus.IsOpen = false;
                }
                IsPopOpenAva = false;
                this.Tap_in.Begin();
                this.LayoutRoot.Background.Opacity=0;
                this.image.Opacity = 0.5;
                this.txtCopyrightContent.Opacity = 0.5;
                this.txtCopyrightTitle.Opacity = 0.5;
                IsTap = true;
            }
        }
        private void a_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (settings["CheckBox3Setting"].ToString() == "false")
                {
                    if (settings["CheckBox3Setting"].ToString() == "false")
                    {
                        IEtask();
                    }
                    else
                    {
                        InternalTask();

                    }
                }
                else if (settings["CheckBox3Setting"].ToString() == "true")
                {
                    MessageBox.Show("回车就可以了哦！");
                    return;
                }
                else
                {
                    if (settings["CheckBox2Setting"].ToString() == "false")
                    {
                        IEtask();
                    }
                    else
                    {
                        InternalTask();

                    }
                
            }
        } 
        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
          this.popus.IsOpen = false;
        }
        #endregion
    }
}