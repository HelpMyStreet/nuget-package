using HelpMyStreet.Utils.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace HelpMyStreet.Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> WhereWithinBoundary<T>(this IEnumerable<T> source, double swLatitude, double swLongitude, double neLatitude, double neLongitude) where T : ILatitudeLongitude
        {
            IEnumerable<T> result = source.Where(pt =>
                pt.Latitude >= swLatitude &&
                pt.Latitude <= neLatitude &&
                pt.Longitude >= swLongitude &&
                pt.Longitude <= neLongitude);

            return result;
        }
    }
}
