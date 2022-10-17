using UnityEngine;

namespace GameObjectExt
{
    public static class GameObjectExtension
    {
        public static T GetOrAdd<T>(this GameObject obj) where T : Component
        {
            var component = obj.GetComponent<T>();
            return component != null
                ? component
                : obj.AddComponent<T>();
        }

        public static void AddComponents(this GameObject obj, params System.Type[] types)
        {
            foreach (var t in types)
                obj.AddComponent(t);
        }

        public static T GetOrAdd<T>(this Component component) where T : Component
            => component.gameObject.GetOrAdd<T>();

        public static GameObject InstantiateWith(this GameObject prefab, Transform parent = null, params System.Type[] types)
        {
            var obj = GameObject.Instantiate(prefab, parent);
            foreach (var t in types)
                obj.AddComponent(t);
            return obj;
        }

        public static T InstantiateComponent<T>(this GameObject prefab, Transform parent = null) where T : Component
            => GameObject.Instantiate(prefab, parent).GetOrAdd<T>();

        public static T InstantiateComponent<T>(this GameObject prefab, string name, Transform parent = null) where T : Component
        {
            var obj = GameObject.Instantiate(prefab, parent);
            obj.name = name;
            return obj.GetOrAdd<T>();
        }
    }

}