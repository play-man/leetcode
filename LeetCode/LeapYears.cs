using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    static class LeapYears
    {
        static List<int> monthShiftsRegularYear = new List<int>() { 3, 0, 3, 2, 3, 2, 3, 3, 2, 3, 2, 3 };
        static List<int> monthShiftsLeapYear = new List<int>() { 3, 1, 3, 2, 3, 2, 3, 3, 2, 3, 2, 3 };
        static int weekDays = 7;

        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0) && (year % 400 != 0);
        }

        public static int MonthCount(DateTime startDate, DateTime endDate, int desiredDayOfWeek, int startDateDayOfWeek)
        {
            int result = 0;
            int currentDayOfWeek = startDateDayOfWeek;
            for (int year = startDate.Year; year <= endDate.Year; ++year)
            {
                int yearStartIndex = (year == startDate.Year ? startDate.Month - 1 : 0);
                int yearEndIndex = (year == endDate.Year ? endDate.Month - 1 : monthShiftsRegularYear.Count - 1);

                for (int j = yearStartIndex; j <= yearEndIndex; ++j)
                {
                    currentDayOfWeek = (currentDayOfWeek + (IsLeapYear(year) ? monthShiftsLeapYear[j] : monthShiftsRegularYear[j])) % weekDays;
                    if (currentDayOfWeek == desiredDayOfWeek)
                        result++;
                }
            }
            return result;
        }

        public static int[,,] arr = new int[,,]
        {
            { {3, 4}, {3, 4}, {3, 4} },
            { {3, 4}, {3, 4}, {3, 4} },
        };

        public static int[][] jagged = new int[][]
        {
            new int[]{ 3, 4, 5 },
            new int[]{ 3, 4, 5 },
        };

        public static readonly int[,,] arrconst = arr;
    }
}
