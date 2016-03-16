using Bing_Search.Resources;

namespace Bing_Search
{
    /// <summary>
    /// 提供对字符串资源的访问权。
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}