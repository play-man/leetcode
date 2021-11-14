using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class DailyTemperature
    {
        /*Given an array of integers temperatures represents the daily temperatures, 
        return an array answer such that answer[i] is the number of days you have to wait 
        after the ith day to get a warmer temperature. 
        If there is no future day for which this is possible, keep answer[i] == 0 instead.*/
        public static int[] DailyTemperaturesDescending(int[] temperatures)
        {
            int[] daysToWait = new int[temperatures.Length];
            int minUnconfirmed = 0;

            for (int i = 0; i < temperatures.Length; i++)
            {
                int nextTempHigherIndex = i;
                while (minUnconfirmed <= i && nextTempHigherIndex < temperatures.Length && temperatures[i] >= temperatures[nextTempHigherIndex])
                {
                    for (int j = Math.Max(i + 1, minUnconfirmed); j < nextTempHigherIndex; j++)
                        if ((temperatures[nextTempHigherIndex] > temperatures[j]))
                        {
                            daysToWait[j] = nextTempHigherIndex - j;
                            if (minUnconfirmed == j)
                                ++minUnconfirmed;
                        }
                    nextTempHigherIndex++;
                }
                if (nextTempHigherIndex == temperatures.Length)
                {
                    daysToWait[i] = 0;
                }
                else
                    daysToWait[i] = nextTempHigherIndex - i;
                if (minUnconfirmed == i)
                    ++minUnconfirmed;
            }

            return daysToWait;
        }
        public static int[] DailyTemperaturesStraightforward(int[] temperatures)
        {
            int[] daysToWait = new int[temperatures.Length];
            for (int i = 0; i < temperatures.Length; i++)
            {
                int nextTempHigherIndex = i;
                while (nextTempHigherIndex < temperatures.Length && temperatures[i] >= temperatures[nextTempHigherIndex])
                    nextTempHigherIndex++;
                if (nextTempHigherIndex == temperatures.Length)
                    daysToWait[i] = 0;
                else
                    daysToWait[i] = nextTempHigherIndex - i;
            }
            return daysToWait;
        }
        public static int[] DailyTemperatures(int[] temperatures)
        {
            int[] daysToWait = new int[temperatures.Length];
            Stack<int> highestTempIndex = new Stack<int>();
            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                while (highestTempIndex.Count > 0 && temperatures[i] >= temperatures[highestTempIndex.Peek()])
                    highestTempIndex.Pop();
                daysToWait[i] = highestTempIndex.Count > 0 ? highestTempIndex.Peek() - i : 0;
                highestTempIndex.Push(i);
            }
            return daysToWait;
        }
    }
}
