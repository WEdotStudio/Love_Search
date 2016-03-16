using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Live;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Phone.Tasks;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bing_Search
{
    public partial class OneNoteShare : PhoneApplicationPage
    {
        private string m_AccessToken = null;
        private StandardResponse m_Response = null;

        // v1.0 Endpoints        
        private const string PAGESENDPOINT = "https://www.onenote.com/api/v1.0/pages";
        public OneNoteShare()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UmengSDK.UmengAnalytics.TrackPageStart("onenote_Share");
            if (NavigationContext.QueryString["readytoshare"] == "")
            {
                NavigationService.GoBack();
            }
            else
            {
               this.readytoshare.Text= NavigationContext.QueryString["readytoshare"];
                
            }
        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            UmengSDK.UmengAnalytics.TrackPageEnd("onenote_Share");
        }
        private void onSessionChanged(object sender, Microsoft.Live.Controls.LiveConnectSessionChangedEventArgs e)
        {
            if (e.Status == LiveConnectSessionStatus.Connected)
            {
                m_AccessToken = e.Session.AccessToken;

                infoTextBlock.Text = "绑定成功。";

            }
            else
            {
                infoTextBlock.Text = "你还未绑定或绑定失败。";
            }


        }

        private async void btn_CreateSimple_Click(object sender, RoutedEventArgs e)
        {
            StartRequest();

            string date = GetDate();

            /////////////// Add the first part /////////////////
            string simpleHtml = "<html>" +
                          "<head>" +
                          "<title>爱搜索扫码结果</title>" +
                          "<meta name=\"created\" content=\"" + date + "\" />" +
                          "</head>" +
                          "<body>" +
                          "<p>" + readytoshare.Text + "</b></p>" +
                          "</body>" +
                          "</html>";

            // Create the request message, which is a multipart/form-data request
            var createMessage = new HttpRequestMessage(HttpMethod.Post, PAGESENDPOINT)
            {
                Content = new StringContent(simpleHtml, System.Text.Encoding.UTF8, "text/html")
            };

            HttpClient httpClient = new HttpClient();

            // Add Authorization header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", m_AccessToken);

            // Note: API only supports JSON return type.
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.SendAsync(createMessage);

            await EndRequest(response);

        }




      

        /// <summary>
        /// Get date in ISO8601 format with local timezone offset
        /// </summary>
        /// <returns>Date as ISO8601 string</returns>
        private static string GetDate()
        {
            return DateTime.Now.ToString("o");
        }


        private void StartRequest()
        {
            infoTextBlock.Text = "创建中...";
            m_Response = null;
        }

        private async Task EndRequest(HttpResponseMessage response)
        {
            m_Response = await TranslateResponse(response);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                infoTextBlock.Text = "创建成功。";
            }
            else
            {
                infoTextBlock.Text = "创建失败。错误代码：" + response.StatusCode;
            }

        }

        private async static Task<StandardResponse> TranslateResponse(HttpResponseMessage response)
        {
            StandardResponse standardResponse;
            if (response.StatusCode == HttpStatusCode.Created)
            {
                dynamic responseObject = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                standardResponse = new CreateSuccessResponse
                {
                    StatusCode = response.StatusCode,
                    OneNoteClientUrl = responseObject.links.oneNoteClientUrl.href,
                    OneNoteWebUrl = responseObject.links.oneNoteWebUrl.href
                };
            }
            else
            {
                standardResponse = new StandardErrorResponse
                {
                    StatusCode = response.StatusCode,
                    Message = await response.Content.ReadAsStringAsync()
                };
            }

            // Extract the correlation id.  Apps should log this if they want to collect data to diagnose failures with Microsoft support 
            IEnumerable<string> correlationValues;
            if (response.Headers.TryGetValues("X-CorrelationId", out correlationValues))
            {
                standardResponse.CorrelationId = correlationValues.FirstOrDefault();
            }

            return standardResponse;
        }

    }
}