using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CustomListExtension
{
    public static class ListExtension
    {
        public static int UniqueCount<T>(this IEnumerable<T> enumerable)
            => enumerable.Distinct().Count();

        public static bool IndexInRange<T>(this IEnumerable<T> enumerable, int index)
            => index < enumerable.Count();
        public static IEnumerable<int> FindAllIndexes<T>(this IEnumerable<T> enumerable, T item)
        {
            int i = 0;

            foreach(T t in enumerable)
            {
                if (t.Equals(item))
                    yield return i;
                i++;
            }
        }

        public static List<T> Randomize<T>(this List<T> list)
        {
            var originalList = new List<T>(list);
            var randomList = new List<T>();

            while (originalList.Count > 0)
            {
                var randomIndex = Random.Range(0, originalList.Count);
                var randomItem = originalList[randomIndex];
                randomList.Add(randomItem);
                originalList.Remove(randomItem);
            }

            return randomList;
        }

        public static List<T> Randomize<T>(this List<T> list, int max)
        {
            var items = Randomize(list);
            var output = new List<T>();

            for (var i = 0; i < max; i++)
            {
                output.Add(items[i]);
            }
            return output;
        }

        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}
