using System;
using System.Windows;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Microsoft.Phone.Tasks;
using System.Net.Http.Headers;
using Microsoft.Live;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Resources;

namespace Bing_Search
{
    public partial class SettingsWithoutConfirmation : PhoneApplicationPage
    {

        public SettingsWithoutConfirmation()
        {
            InitializeComponent();
            
        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.checkBox5Setting.IsChecked == true)
            {
                checkBox5Setting.Content = "开启";
            }
            else if (this.checkBox5Setting.IsChecked == false)
            {
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                checkBox5Setting.Content = "关闭";
            }
            if (this.checkBox1Setting.IsChecked == true)
            {
                checkBox1Setting.Content = "按钮形式搜索";
            }
            else if (this.checkBox1Setting.IsChecked == false)
            {
                checkBox1Setting.Content = "回车搜索";
           }
            if (this.checkBox2Setting.IsChecked == true)
            {
                checkBox2Setting.Content = "是";
            }
            else if (this.checkBox2Setting.IsChecked == false)
            {
                checkBox2Setting.Content = "否";
            }
            if (this.checkBox3Setting.IsChecked == true)
            {
                checkBox3Setting.Content = "单一输入样式";
                checkBox1Setting.IsEnabled = true;
            }
            else if (this.checkBox3Setting.IsChecked == false)
            {
                checkBox3Setting.Content = "按钮/回车输入共存";
                checkBox1Setting.IsEnabled = false;

            }
            if (this.checkBox4Setting.IsChecked == true)
            {
                checkBox4Setting.Content = "显示";

            }
            else if (this.checkBox4Setting.IsChecked == false)
            {
                checkBox4Setting.Content = "不显示";

            }
        }

        private void toggleSwitch1_Checked(object sender, RoutedEventArgs e)
        {
            checkBox1Setting.Content = "按钮形式搜索";
        }

        private void toggleSwitch1_Unchecked(object sender, RoutedEventArgs e)
        {
            checkBox1Setting.Content = "回车搜索";
        }
        private void toggleSwitch2_Checked(object sender, RoutedEventArgs e)
        {
            checkBox2Setting.Content = "是";
        }

        private void toggleSwitch2_Unchecked(object sender, RoutedEventArgs e)
        {
            checkBox2Setting.Content = "否";
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/firstrun.xaml", UriKind.Relative));
        }

        private void checkBox3Setting_Checked(object sender, RoutedEventArgs e)
        {
            checkBox3Setting.Content = "单一输入样式";
            checkBox1Setting.IsEnabled = true;
        }

        private void toggleSwitc3_Unchecked(object sender, RoutedEventArgs e)
        {
            checkBox3Setting.Content = "按钮/回车输入共存";
            checkBox1Setting.IsEnabled = false;
        }

        private void toggleSwitch4_Checked(object sender, RoutedEventArgs e)
        {
            checkBox4Setting.Content = "显示";
        }

        private void toggleSwitch4_Unchecked(object sender, RoutedEventArgs e)
        {
            checkBox4Setting.Content = "不显示";
        }

        private void toggleSwitch5_Unchecked(object sender, RoutedEventArgs e)
        {
            checkBox5Setting.Content = "关闭";
        }

        private void toggleSwitch5_Checked(object sender, RoutedEventArgs e)
        {
            checkBox5Setting.Content = "开启";
        }
       

    }
}
