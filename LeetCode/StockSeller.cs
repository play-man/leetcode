using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class StockSeller
    {
        public static int MaxProfit(int[] prices)
        {
            int result = 0;
            int buy = 0;
            int sell = 0;
            for (int i = 0; i < prices.Length - 1; ++i)
            {
                if (prices[i + 1] < prices[i])
                {
                    result += prices[sell] - prices[buy] > 0 ? prices[sell] - prices[buy] : 0;
                    buy = i + 1;
                    sell = i + 1;
                }
                else if (prices[i + 1] > prices[i])
                {
                    sell = i + 1;
                }
            }
            result += prices[sell] - prices[buy];
            return result;
        }
    }
}
