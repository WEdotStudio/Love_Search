using System.Xml.Linq;

namespace Bing_Search.Entity
{
    /// <summary>
    /// 图片相关信息
    /// </summary>
    public class Message
    {
        #region 属性
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 描述文本
        /// </summary>
        public string Text { get; set; }
        #endregion

        #region 构造函数
        protected Message()
        { 
            
        }
        #endregion

        /// <summary>
        /// 根据XElement对象生成Message对象
        /// </summary>
        /// <param name="msgXElement">XElement对象</param>
        /// <returns></returns>
        internal static Message CreateMessage(XElement msgXElement)
        {
            Message msg = new Message();

            msg.Title = msgXElement.Element("msgtitle").Value;
            msg.Link = msgXElement.Element("msglink").Value;
            msg.Text = msgXElement.Element("msgtext").Value;

            return msg;
        }
    }
}