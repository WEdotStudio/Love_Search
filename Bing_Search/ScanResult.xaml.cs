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
using System.Windows.Navigation;
using Bing_Search;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Phone.Tasks;
using System.Net.Http.Headers;
using Microsoft.Live;

namespace WP7BarcodeScannerExample
{
    public partial class ScanResult : PhoneApplicationPage
    {
        
        public ScanResult()
        {
            InitializeComponent();

            scanResult.Text = "";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string result = "";
            if (NavigationContext.QueryString.TryGetValue("result", out result))
            {
              scanResult.Text += result + "\r\n";       
            }
            base.OnNavigatedTo(e);
            UmengSDK.UmengAnalytics.TrackPageStart("scan_result");
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            var lastPage = NavigationService.BackStack.FirstOrDefault();
            if (lastPage != null && lastPage.Source.ToString().Contains("/BarCode.xaml")&&lastPage.Source.ToString().Contains("/Page1.xaml"))
            {
                NavigationService.RemoveBackEntry();
            }

            base.OnNavigatingFrom(e);
            UmengSDK.UmengAnalytics.TrackPageStart("scan_result");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a=this.scanResult.Text;
            Clipboard.SetText(a);
        }
        
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void btn_CreateSimple_Click(object sender, RoutedEventArgs e)
        {
            string a=this.scanResult.Text;
            NavigationService.Navigate(new Uri("/OneNoteShare.xaml?reallytoshare=" + a, UriKind.Relative));
        }
    

    }
}