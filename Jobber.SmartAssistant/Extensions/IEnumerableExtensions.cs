using System;
using System.Collections.Generic;
using System.Linq;
using Jobber.Sdk.Models.Jobs;

namespace Jobber.SmartAssistant.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> SelectWhere<T>(this IEnumerable<T> enumerable, Func<T, bool> matcher, Func<T, T> mapper)
        {
            return enumerable.Select(i => matcher(i) ? mapper(i) : i);
        }
    }
}