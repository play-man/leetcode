using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class StockSpanner
    {
        List<int> prices;
        Stack<int> stack;
        public StockSpanner()
        {
            prices = new List<int>();
            stack = new Stack<int>();
        }

        public int Next(int price)
        {
            int result = 1;
            prices.Add(price);
            for (int i = prices.Count - 1; i >= 0; i--)
            {
                while ((stack.Count > 0) && (prices[stack.Peek()] <= prices[i]))
                    stack.Pop();
                if (stack.Count == 0)
                {
                    stack.Push(i);
                    result = i + 1;
                    break;
                }
                else
                {
                    result = i - stack.Peek();
                    stack.Push(i);
                    break;
                }
            }
            return result;
        }
    }
}
