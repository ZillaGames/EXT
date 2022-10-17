using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace LinqExt
{
    public static class LinqExtension
    {
        public static TObject MinObj<TObject, TResult>(this IEnumerable<TObject> objects, Func<TObject, TResult> func)
            where TResult : IComparable<TResult>
        {
            switch(objects.Count())
            {
                case 0: throw new Exception("Enumerable is empty!");
                case 1: return objects.Single();
                default:
                    var min = objects.First();
                    var minValue = func.Invoke(min);

                    foreach(var obj in objects)
                    {
                        var val = func.Invoke(obj);
                        if(val.CompareTo(minValue) < 0)
                        {
                            minValue = val;
                            min = obj;
                        }
                    }
                    return min;
            }
        }

        public static int MinIndex<T>(this IEnumerable<T> objects) where T : IComparable<T>
        {
            var minValue = objects.First();
            int minIndex = 0;
            int i = 0;

            foreach (var obj in objects)
            {
                if (obj.CompareTo(minValue) < 0)
                {
                    minValue = obj;
                    minIndex = i;
                }

                i++;
            }

            return minIndex;
        }

        public static TObject MaxObj<TObject, TResult>(this IEnumerable<TObject> objects, Func<TObject, TResult> func)
            where TResult : IComparable<TResult>
        {
            switch (objects.Count())
            {
                case 0: throw new Exception("Enumerable is empty!");
                case 1: return objects.Single();
                default:
                    var max = objects.First();
                    var maxValue = func.Invoke(max);

                    foreach (var obj in objects)
                    {
                        var val = func.Invoke(obj);
                        if (val.CompareTo(maxValue) > 0)
                        {
                            maxValue = val;
                            max = obj;
                        }
                    }
                    return max;
            }

        }

        public static int MaxIndex<T>(this IEnumerable<T> objects)
            where T : IComparable<T>
        {
            var maxValue = objects.First();
            int maxIndex = 0;
            int i = 0;

            foreach(var obj in objects)
            {
                if(obj.CompareTo(maxValue) > 0)
                {
                    maxValue = obj;
                    maxIndex = i;
                }

                i++;
            }

            return maxIndex;
        }
        public static IEnumerable<T> Except<T>(this IEnumerable<T> objects, T obj) => objects.Where(t => !t.Equals(obj));
        public static IEnumerable<T> ExceptGroup<T>(this IEnumerable<T> objects, params T[] objs) => objects.Except(objs);
        public static bool Contains<TObject, TComparer>(this IEnumerable<TObject> collection, TComparer value, Func<TObject, TComparer> selector, out TObject obj)
        {
            var contains = collection.Select(selector).Contains(value);

            obj = contains
                ? collection.First(o => selector.Invoke(o).Equals(value))
                : default(TObject);

            return contains;

        }

        public static IEnumerable<T> With<T>(this IEnumerable<T> @this, T item)
        {
            foreach (var cur in @this)
                yield return cur;

            yield return item;
        }
    }
}