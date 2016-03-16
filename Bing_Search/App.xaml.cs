using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Bing_Search.Resources;
using Windows.Phone.Speech.VoiceCommands;
using Microsoft.Phone.Net.NetworkInformation;
using Windows.Phone.Storage.SharedAccess;
using System.IO.IsolatedStorage;

namespace Bing_Search
{
    public partial class App : Application
    {
        public static PhoneApplicationFrame RootFrame { get; private set; }

        public App()
        {
            UnhandledException += Application_UnhandledException;

            InitializeComponent();

            InitializePhoneApplication();

            InstallVoiceCommands();

            InitializeLanguage();
            UmengSDK.UmengAnalytics.Init("53d37a3c56240b2b9e0a3288", "Marketplace");

            if (Debugger.IsAttached)
            {

                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }


        }

        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            
        }


        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }


        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }


        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }


        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {

            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }


        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        #region 电话应用程序初始化

        private bool phoneApplicationInitialized = false;

        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;


            RootFrame = new PhoneApplicationFrame();
            RootFrame.UriMapper = new AssociationUriMapper();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            RootFrame.Navigated += CheckForResetNavigation;

            phoneApplicationInitialized = true;
        }

        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            RootFrame.Navigated -= ClearBackStackAfterReset;

            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            while (RootFrame.RemoveBackEntry() != null)
            {
                ; 
            }
        }

        #endregion

        private void InitializeLanguage()
        {
            try
            {

                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);


                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
            }
            catch
            {

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }
        private async void InstallVoiceCommands()
        {
            const string wp80 = "ms-appx:///ChineseVoiceCommandDefinition_8.0.xml";
            const string wp81 = "ms-appx:///ChineseVoiceCommandDefinition_8.1.xml";

            bool wp81versionneeded = 
                ((Environment.OSVersion.Version.Major >= 8) 
                && 
                (Environment.OSVersion.Version.Minor >= 10));
            
            string VcdUri = wp81versionneeded ? wp81 : wp80;
            
            await VoiceCommandService.InstallCommandSetsFromFileAsync(new Uri(VcdUri));
        }

    }
    class AssociationUriMapper : UriMapperBase
    {
        private string tempUri;
        public override Uri MapUri(Uri uri)
        {
            tempUri = uri.ToString();
            // 根据文件类型打开程序
            if (tempUri.Contains("/FileTypeAssociation"))
            {
                // 获取fileID (after "fileToken=").
                int fileIDIndex = tempUri.IndexOf("fileToken=") + 10;
                string fileID = tempUri.Substring(fileIDIndex);
                // 获取文件名.
                string incommingFileName = SharedStorageAccessManager.GetSharedFileName(fileID);
                // 获取文件后缀
                int extensionIndex = incommingFileName.LastIndexOf('.') + 1;
                string incommingFileType = incommingFileName.Substring(extensionIndex).ToLower();
                // 根据不同文件类型，跳转不同参数的地址
                switch (incommingFileType)
                {
                    case "wx5ebe851b58f090d4":
                        return new Uri("/WCEntry.xaml?fileToken=" + fileID, UriKind.Relative);
                    default:
                        return new Uri("/MainPage.xaml", UriKind.Relative);
                }
            }
            else
            {
                return uri;
            }
        }
    }

    
}