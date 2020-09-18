using System;
using System.Linq;

namespace HelpMyStreet.Utils.Extensions
{
    public static class ConditionalIncludesExtensions
    {
        public static IQueryable<T> If<T>(
    this IQueryable<T> source,
    bool condition,
    Func<IQueryable<T>, IQueryable<T>> transform
)
        {
            return condition ? transform(source) : source;
        }
    }
}
