using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Bing_Pic.Resources;
using LoveSearchCore.Entity;
using Microsoft.Phone.Tasks;
using LoveSearchCore.Core;
using Microsoft.Xna.Framework.Media;

namespace Bing_Pic
{
    public partial class MainPage : PhoneApplicationPage
    {
        protected BingImage _currentBingImg;
        protected int _currentImgIndex;
        protected WebBrowserTask _browserTask;
        protected PhotoChooserTask _photoChooserTask;
        protected ProgressIndicator tProgIndicator;
        public MainPage()
        {
            InitializeComponent();

            GetImage();
            InitMenber();
        }

        #region BingPhotoCore
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

        private void InitMenber()
        {
            _currentBingImg = null;
            _currentImgIndex = BingImageCollection.MIN_INDEX;

            _browserTask = new WebBrowserTask();
            _photoChooserTask = new PhotoChooserTask();
            tProgIndicator = new ProgressIndicator();
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
                    this.imageshadow.DataContext = _currentBingImg;
                    this.txtCopyrightTitle.DataContext = _currentBingImg;
                });
                InvokeAction(showImgAction);


            }
            else
            {
                throw new Exception("无法获取到图片，请确认网络是否链接正常！");
            }

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

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            tProgIndicator.IsVisible = true;
            tProgIndicator.IsIndeterminate = true;
            tProgIndicator.Text = "载入Bing每日一图中...";

            SystemTray.SetProgressIndicator(this, tProgIndicator);

        }


        private void image_ImageOpened(object sender, RoutedEventArgs e)
        {
            tProgIndicator.IsVisible = false;
            SystemTray.SetProgressIndicator(this, tProgIndicator);
        }

        private void RoundButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}