using System.Collections.Generic;
using static UnityEngine.Random;
using System.Linq;

namespace RandomCollectionExt
{
    public static class RandomCollectionExtension
    {
        public static T Random<T>(this IEnumerable<T> list)
            => list.ElementAt(Range(0, list.Count()));

        public static T Random<T>(this IEnumerable<T> list, IEnumerable<float> weights)
        {
            var v = value;

            for(int i = 0; i < list.Count(); i++)
            {
                if ((v -= weights.ElementAt(i)) <= 0)
                    return list.ElementAt(i);
            }

            return list.Last();
        }

    }

}
