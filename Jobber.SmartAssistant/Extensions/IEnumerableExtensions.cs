using System;
using System.Collections.Generic;
using System.Linq;
using Jobber.Sdk.Models.Jobs;

namespace Jobber.SmartAssistant.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T GetValueAt<T>(this IEnumerable<T> enumerable, int index)
        {
            var currIndex = 0;
            
            foreach (var val in enumerable)
            {
                if (currIndex == index)
                {
                    return val;
                }

                currIndex++;
            }

            throw new IndexOutOfRangeException();
        }
        
        public static IEnumerable<T> SelectWhere<T>(this IEnumerable<T> enumerable, Func<T, bool> matcher, Func<T, T> mapper)
        {
            return enumerable.Select(i => matcher(i) ? mapper(i) : i);
        }

        public static string ToCommaSeperatedSentence(this IEnumerable<string> items)
        {
            if (items.Count() == 2)
            {
                return $"{items.GetValueAt(0)} and {items.GetValueAt(1)}";
            }
            
            var commaJoinedItems = String.Join(", ", items);
            var lastCommaIndex = commaJoinedItems.LastIndexOf(",");

            return commaJoinedItems.Insert(lastCommaIndex + 1, " and");
        }
    }
}