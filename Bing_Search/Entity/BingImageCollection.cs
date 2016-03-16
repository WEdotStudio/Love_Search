using System.Collections.Generic;
using System.Net;
using System.IO;
using System;
using System.Security;
using System.Xml;
using System.Xml.Linq;

namespace Bing_Search.Entity
{
    /// <summary>
    /// Bing图片信息集合
    /// </summary>
    public class BingImageCollection : List<BingImage>
    {
        #region 常量
        /// <summary>
        /// 请求地址的格式化字符串（例如：http://cn.bing.com/HPImageArchive.aspx?idx=0&n=2）
        /// </summary>
        private const string REQUEST_URL_FORMAT_STR = "http://cn.bing.com/HPImageArchive.aspx?idx={0}&n={1}";
        /// <summary>
        /// 请求参数idx的最小值
        /// </summary>
        public const int MIN_INDEX = 0;
        /// <summary>
        /// 请求参数idx的最大值
        /// </summary>
        public const int MAX_INDEX = 13;
        /// <summary>
        /// 请求参数n的最小值
        /// </summary>
        public const int MIN_NUMBER = 0;
        /// <summary>
        /// 请求参数n的最大值
        /// </summary>
        public const int MAX_NUMBER = 8;
        #endregion

        #region 属性
        /// <summary>
        /// 图片加载中的提示信息
        /// </summary>
        public string LoadingMessage { get; set; }
        /// <summary>
        /// 上一张图片的链接文本
        /// </summary>
        public string PreviousImageText { get; set; }
        /// <summary>
        /// 下一张图片的链接文本
        /// </summary>
        public string NextImageText { get; set; }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取Bing图片（集合）
        /// </summary>
        /// <param name="index">几天以前（默认为0，表示当天的图片，1就表示1天以前的图片）</param>
        /// <param name="number"> 图片数量，最大为8，图片返回顺序为由新到旧</param>
        /// <param name="callBack">回调函数</param>
        /// <returns></returns>
        public static void GetBingImages(int index, int number, Action<BingImageCollection> callBack)
        {
            #region 对传入参数进行修正
            if (index < MIN_INDEX) index = MIN_INDEX;
            else if (index > MAX_INDEX) index = MAX_INDEX;

            if (number < MIN_INDEX) number = MIN_INDEX;
            else if (number > MAX_NUMBER) number = MAX_NUMBER;
            #endregion

            // 数据请求地址
            string requestUriString = string.Format(REQUEST_URL_FORMAT_STR, index, number);

            // 请求数据
            WebRequest request = WebRequest.Create(new Uri(requestUriString));
            request.BeginGetResponse(new AsyncCallback((ar) =>
            {
                HttpWebRequest theRequest = ar.AsyncState as HttpWebRequest;
                if (theRequest != null)
                {
                    // 获取xml
                    WebResponse response = theRequest.EndGetResponse(ar);
                    Stream stream = response.GetResponseStream();
                    XDocument xdoc = XDocument.Load(stream);

                    // 把XDocument对象解析为BingImageCollection对象
                    BingImageCollection imgCollection = XDoc2BingImgs(xdoc);

                    // 调用回调函数
                    callBack(imgCollection);
                }
            }), request);
        }

        /// <summary>
        /// 把XDocument对象解析为BingImageCollection对象
        /// </summary>
        /// <param name="xdoc">XDocument</param>
        /// <returns></returns>
        private static BingImageCollection XDoc2BingImgs(XDocument xdoc)
        {
            BingImageCollection bic = new BingImageCollection();

            // 根节点
            var rootNode = xdoc.Element("images");

            var toolTipsElement = rootNode.Element("tooltips");
            var loadMsgElement = toolTipsElement.Element("loadMessage").Element("message");
            var preImgElement = toolTipsElement.Element("previousImage").Element("text");
            var nextImgElement = toolTipsElement.Element("nextImage").Element("text");

            bic.LoadingMessage = loadMsgElement != null ? loadMsgElement.Value : "";
            bic.PreviousImageText = preImgElement != null ? preImgElement.Value : "";
            bic.NextImageText = nextImgElement != null ? nextImgElement.Value : "";

            var imgElement = rootNode.Elements("image");
            foreach (var item in imgElement)
            {
                BingImage bingImg = BingImage.CreateBingImage(item);
                bic.Add(bingImg);
            }

            return bic;
        }
        #endregion
    }
}