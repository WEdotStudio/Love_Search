using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Info;

namespace Bing_Search
{
    public partial class dia : PhoneApplicationPage
    {
        public dia()
        {
            InitializeComponent();
            this.Loaded += (sender, e) =>
            {
                this.a.Text = DeviceStatus.DeviceName;
                this.b.Text = DeviceStatus.DeviceManufacturer;
                this.c.Text = DeviceStatus.DeviceFirmwareVersion;
                this.d.Text = DeviceStatus.DeviceHardwareVersion;
                this.e.Text = Convert.ToSingle(DeviceStatus.DeviceTotalMemory / 1024 / 1024).ToString("0.00") + "MB";
                this.f.Text = Convert.ToSingle(DeviceStatus.ApplicationCurrentMemoryUsage / 1024 / 1024).ToString("0.00") + "MB";
                this.g.Text = Convert.ToSingle(DeviceStatus.ApplicationMemoryUsageLimit / 1024 / 1024).ToString("0.00") + "MB";
                this.h.Text = Convert.ToSingle(DeviceStatus.ApplicationPeakMemoryUsage / 1024 / 1024).ToString("0.00") + "MB";
                this.m.Text = DeviceExtendedProperties.GetValue("OriginalMobileOperatorName").ToString();
            };
        }

    }
}