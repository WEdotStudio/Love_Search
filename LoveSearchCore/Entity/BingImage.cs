using System;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace Love_Search_2._0.Entity
{
    /// <summary>
    /// Bing图片信息
    /// </summary>
    public class BingImage
    {
        #region 常量
        /// <summary>
        /// Bing的地址
        /// </summary>
        private const string BING_URL = "http://www.bing.com";
        /// <summary>
        /// 图片默认宽度
        /// </summary>
        public const int DEFAULT_WIDTH = 1080;
        /// <summary>
        /// 图片默认高度
        /// </summary>
        public const int DEFAULT_HEIGHT = 1920;
        #endregion


        #region 属性
        /// <summary>
        /// 图片开始在首页显示的时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 图片结束在首页显示的时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 图片的Url地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图片的版权信息
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Drk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Top { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Bot { get; set; }

        /// <summary>
        /// 图片热点集合
        /// </summary>
        public HotSpotCollection HotSpots { get; set; }

        /// <summary>
        /// 图片相关信息集合
        /// </summary>
        public MessageCollection Messages { get; set; }

        /// <summary>
        /// 图片的版权信息
        /// </summary>
        private string _copyrightTitle;
        /// <summary>
        /// 图片的版权信息
        /// </summary>
        public string CopyrightTitle
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(_copyrightTitle))
                    {
                        char[] splitChar = { '(' };
                        _copyrightTitle = Copyright.Split(splitChar)[0];
                    }
                }
                catch (Exception)
                {
                    _copyrightTitle = "";
                }
                return _copyrightTitle;
            }
        }

        /// <summary>
        /// 图片的版权信息
        /// </summary>
        private string _copyrightContent;
        /// <summary>
        /// 图片的版权信息
        /// </summary>
        public string CopyrightContent
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(_copyrightContent))
                    {
                        char[] splitChar = { '(' };
                        var re = Copyright.Split(splitChar)[1];
                        _copyrightContent = re.Substring(0, re.Length - 1);
                    }
                }
                catch (Exception)
                {
                    _copyrightContent = "";
                }
                return _copyrightContent;
            }
        }


        /// <summary>
        /// 图片的Index值
        /// </summary>
        public int Index
        {
            get
            {
                return (DateTime.Now - StartDate).Days - 1 + BingImageCollection.MIN_INDEX;
            }
        }
        #endregion


        /// <summary>
        /// 构造函数
        /// </summary>
        private BingImage()
        {
            HotSpots = new HotSpotCollection();
            Messages = new MessageCollection();
        }
        
        /// <summary>
        /// 根据XElement对象生成BingImage对象
        /// </summary>
        /// <param name="imgXElement"></param>
        /// <returns></returns>
        internal static BingImage CreateBingImage(XElement imgXElement)
        {
            BingImage bingImg = new BingImage();

            // 获取图片的基本属性
            bingImg.StartDate = DateTime.ParseExact(imgXElement.Element("fullstartdate").Value, "yyyyMMddHHmm", null);
            bingImg.EndDate = DateTime.ParseExact(imgXElement.Element("enddate").Value, "yyyyMMdd", null);
            bingImg.Url = BING_URL + "/" + imgXElement.Element("urlBase").Value.Trim('/') +"_1080x1920.jpg";
            bingImg.Copyright = imgXElement.Element("copyright").Value;
            bingImg.Drk = Convert.ToInt32(imgXElement.Element("drk").Value);
            bingImg.Top = Convert.ToInt32(imgXElement.Element("top").Value);
            bingImg.Bot = Convert.ToInt32(imgXElement.Element("bot").Value);

            // 获取图片热点信息
            var hotSportXElements = imgXElement.Element("hotspots").Elements("hotspot");
            foreach (var hotSportXElement in hotSportXElements)
            {
                HotSpot hotSpot = HotSpot.CreateHotSpot(hotSportXElement);
                bingImg.HotSpots.Add(hotSpot);
            }

            // 获取图片相关信息
            var msgXElements = imgXElement.Element("messages").Elements("message");
            foreach (var msgXElement in msgXElements)
            {
                Message msg = Message.CreateMessage(msgXElement);
                bingImg.Messages.Add(msg);
            }

            return bingImg;
        }

        /// <summary>
        /// 获取Bing图片
        /// </summary>
        /// <param name="index">几天以前（默认为0，表示当天的图片，1就表示1天以前的图片）</param>
        /// <param name="callBack">回调函数</param>
        /// <returns></returns>
        public static void GetBimgImage(int index, Action<BingImage> callBack)
        {
            BingImageCollection.GetBingImages(index, 1, new Action<BingImageCollection>((bic) =>
            {
                callBack(bic[0]);
            }));
        }
    }
}