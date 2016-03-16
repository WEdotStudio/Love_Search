using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Love_Search_2._0.Core
{
    class TaskCore
    {
        public static void RandomReview()
        {
            Random ran = new Random();
            int value = ran.Next(1, 10);
            if (value == 5)
            {
                var result = MessageBox.Show("求个五星好评，开发不易啊！", "爱搜索", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }
            }
        }
        public static void Alert(string msg)
        {
            MessageBox.Show(msg, "程序提示", MessageBoxButton.OK);
        }
        public static bool Confirm(string msg)
        {
            return MessageBox.Show(msg, "程序提示", MessageBoxButton.OKCancel) == MessageBoxResult.OK;
        }
    }
}
