using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class StockSellerIII
    {
        public static int MaxProfit(int[] prices)
        {
            int result = 0;
            int currentBuy = 0;
            int currentSell = 0;
            List<int> buyList = new List<int>();
            List<int> sellList = new List<int>();

            for (int i = 0; i < prices.Length - 1; ++i)
            {
                if (prices[i + 1] < prices[i])
                {
                    if (prices[currentSell] - prices[currentBuy] > 0)
                    {
                        buyList.Add(prices[currentBuy]);
                        sellList.Add(prices[currentSell]);
                    }
                    currentBuy = i + 1;
                    currentSell = i + 1;
                }
                else if (prices[i + 1] > prices[i])
                {
                    currentSell = i + 1;
                }
            }
            if (prices[currentSell] - prices[currentBuy] > 0)
            {
                buyList.Add(prices[currentBuy]);
                sellList.Add(prices[currentSell]);
            }

            if (buyList.Count == 1)
            {
                result = sellList[0] - buyList[0];
            }
            else
            {
                for (int i = 0; i < buyList.Count - 1; ++i)
                {
                    int a = MaxProfitSingle(buyList.GetRange(0, i + 1), sellList.GetRange(0, i + 1));
                    int b = MaxProfitSingle(buyList.GetRange(i + 1, buyList.Count - i - 1), sellList.GetRange(i + 1, sellList.Count - i - 1));
                    int currentIndexMax = MaxProfitSingle(buyList.GetRange(0, i + 1), sellList.GetRange(0, i + 1)) + MaxProfitSingle(buyList.GetRange(i + 1, buyList.Count - i - 1), sellList.GetRange(i + 1, sellList.Count - i - 1));

                    if (currentIndexMax > result)
                        result = currentIndexMax;
                }
            }
            return result;
        }

        public static int MaxProfitSingle(List<int> buyList, List<int> sellList)
        {
            int result = 0;
            if (buyList.Count == 1)
                return sellList[0] - buyList[0];
            else
            {
                for (int i = 0; i < buyList.Count; ++i)
                {
                    int currentMax = sellList.GetRange(i, sellList.Count - i).Max() - buyList.GetRange(0, i + 1).Min();
                    if (currentMax > result)
                        result = currentMax;
                }
                return result;
            }
        }
    }
}
