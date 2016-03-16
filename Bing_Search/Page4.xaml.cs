using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Bing_Search
{
    public partial class Page4 : PhoneApplicationPage
    {
        public Page4()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            UmengSDK.UmengAnalytics.TrackPageEnd("scan_main");
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UmengSDK.UmengAnalytics.TrackPageStart("scan_main");
        }
        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BarCode.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BarCode.xaml?type=qrcode", UriKind.Relative));
        }
    }
}