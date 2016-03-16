using System;
using System.Xml.Linq;

namespace LoveSearchCore.Entity
{
    /// <summary>
    /// 图片热点
    /// </summary>
    public class HotSpot
    {
        #region 属性
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 问题
        /// </summary>
        public string Query { get; set; }
        /// <summary>
        /// 热点的X坐标（相对于图片左上角）
        /// </summary>
        public int LocX { get; set; }
        /// <summary>
        /// 热点的Y坐标（相对于图片左上角）
        /// </summary>
        public int LocY { get; set; }
        #endregion

        #region 构造方法
        protected HotSpot()
        { 
        
        }
        #endregion

        /// <summary>
        /// 根据XElement对象生成HotSpot对象
        /// </summary>
        /// <param name="hotSportXElement">XElement对象</param>
        /// <returns></returns>
        internal static HotSpot CreateHotSpot(XElement hotSportXElement)
        {
            HotSpot hopSport = new HotSpot();

            hopSport.Desc = hotSportXElement.Element("desc").Value;
            hopSport.Link = hotSportXElement.Element("link").Value;
            hopSport.Query = hotSportXElement.Element("query").Value;
            hopSport.LocX = Convert.ToInt32(hotSportXElement.Element("LocX").Value);
            hopSport.LocY = Convert.ToInt32(hotSportXElement.Element("LocY").Value);

            return hopSport;
        }
    }
}