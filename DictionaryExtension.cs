using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DictionaryExt
{
    public static class DictionaryExtension
    {
        public static void AddByName<T>(this IDictionary<string, T> dict, T Object) where T : UnityEngine.Object
            => dict.Add(Object.name, Object);
        
        public static void RemoveByName<T>(this IDictionary<string, T> dict, T Object) where T : UnityEngine.Object
            => dict.Remove(Object.name);

        public static IEnumerable<TKey> KeysWhere<TKey, TValue>(this IDictionary<TKey,TValue> dict, Func<KeyValuePair<TKey, TValue>, bool> selector)
        {
            foreach(var kvp in dict)
                if (selector.Invoke(kvp))
                    yield return kvp.Key;
        }
    }

}
