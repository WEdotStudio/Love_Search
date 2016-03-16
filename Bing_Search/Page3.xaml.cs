using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace Bing_Search
{
    public partial class Page3 : PhoneApplicationPage
    {
        public Page3()
        {
            InitializeComponent();

            //Microsoft.Phone.Notification.HttpNotificationChannel MyChannel = null;
            //string MyChannelName = "RawNotification";

            //MyChannel = Microsoft.Phone.Notification.HttpNotificationChannel.Find(MyChannelName);
            //if (MyChannel == null)
            //{
            //    MyChannel = new Microsoft.Phone.Notification.HttpNotificationChannel(MyChannelName);
            //    MyChannel.ChannelUriUpdated += new EventHandler<Microsoft.Phone.Notification.NotificationChannelUriEventArgs>(MyChannel_ChannelUriUpdated);
             //   MyChannel.ErrorOccurred += new EventHandler<Microsoft.Phone.Notification.NotificationChannelErrorEventArgs>(MyChannel_ErrorOccurred);
             //   MyChannel.HttpNotificationReceived += new EventHandler<Microsoft.Phone.Notification.HttpNotificationEventArgs>(MyChannel_HttpNotificationReceived);
            //    MyChannel.Open();
           // }
           // else
           // {
           //     MyChannel.ErrorOccurred += new EventHandler<Microsoft.Phone.Notification.NotificationChannelErrorEventArgs>(MyChannel_ErrorOccurred);
           //     MyChannel.ChannelUriUpdated += new EventHandler<Microsoft.Phone.Notification.NotificationChannelUriEventArgs>(MyChannel_ChannelUriUpdated);
           //     MyChannel.HttpNotificationReceived += new EventHandler<Microsoft.Phone.Notification.HttpNotificationEventArgs>(MyChannel_HttpNotificationReceived);
           //     System.Diagnostics.Debug.WriteLine("URI: {0}", MyChannel.ChannelUri.ToString());
           // }
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.howto.IsOpen = true;
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Clipboard.SetText("122.132.104.224");
            MessageBox.Show("已复制地址一");
        }

        private void TextBlock_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Clipboard.SetText("41.138.187.104");
            MessageBox.Show("已复制地址二");
        }

        private void TextBlock_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Clipboard.SetText("211.2.103.69");
            MessageBox.Show("已复制地址三");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.howto.IsOpen = false;
        }

        private void TextBlock_Tap_4(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Clipboard.SetText("115.177.61.56");
            MessageBox.Show("已复制地址四");
        }

        private void TextBlock_Tap_5(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Clipboard.SetText("85.238.116.162");
            MessageBox.Show("已复制地址五");
        }
        
        //void MyChannel_HttpNotificationReceived(object sender, Microsoft.Phone.Notification.HttpNotificationEventArgs e)
        //{
         //   string msg = "";
         //   using (System.IO.Stream stream = e.Notification.Body)
          //  {
           //     System.IO.StreamReader reader = new System.IO.StreamReader(stream);
           //     msg = reader.ReadToEnd();
           //     reader.Close();
           // }
           // Dispatcher.BeginInvoke(() =>
           // {
             //   this.txtBody.Text = string.Format("{0}\r\n" +
            //                                    "------------------------------\r\n" +
             //                                   "{1}",
             //                                   DateTime.Now.ToLongTimeString(),
             //                                   msg);

           // });

       // }

       // void MyChannel_ErrorOccurred(object sender, Microsoft.Phone.Notification.NotificationChannelErrorEventArgs e)
       // {
       //     Dispatcher.BeginInvoke(() =>
        //    {
        //        MessageBox.Show("错误信息：\n" + e.Message);
        //    });
        //}

        //void MyChannel_ChannelUriUpdated(object sender, Microsoft.Phone.Notification.NotificationChannelUriEventArgs e)
        //{
         //   Dispatcher.BeginInvoke(() =>
          //  {
         //       System.Diagnostics.Debug.WriteLine("URI: {0}", e.ChannelUri.ToString());
         //   });
       // }
    }
}