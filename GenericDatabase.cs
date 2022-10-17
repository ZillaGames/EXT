using DictionaryExt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDatabase<T> : ScriptableObject /*, IEnumerable<T> where T : Object */
{
    /*
    [SerializeField] protected SerializableDictionary<string, T> Database;

    public T this[string str]
    {
        get => Database[str];
        set => Database[str] = value;
    }

    public void Add(T obj) => Database.AddByName(obj);

    public void Remove(T obj) => Database.RemoveByName(obj);

    public bool Contains(T obj) => Database.Values.Contains(obj);
    public bool ContainsKey(string key) => Database.ContainsKey(key);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => Database.Values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => Database.Values.GetEnumerator();

    public IEnumerable<T> Values => Database.Values;
    */
}
