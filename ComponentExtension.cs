using LinqExt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ComponentExt
{
    public static class ComponentExtension
    {
        public static TObject ClosestTo<TObject>(this IEnumerable<TObject> objects, Vector3 pos) where TObject : Component
            => objects.Count() switch
            {
                0 => throw new Exception($"Object list is Empty! Cannot find closest!"),
                1 => objects.First(),
                _ => objects.MinObj(obj => Vector3.Distance(pos, obj.transform.position))
            };

        public static TObject FarthestFrom<TObject>(this IEnumerable<TObject> objects, Vector3 pos) where TObject : Component
            => objects.Count() switch
            {
                0 => throw new Exception($"Object list is Empty! Cannot find farthest!"),
                1 => objects.First(),
                _ => objects.MaxObj(obj => Vector3.Distance(pos, obj.transform.position))
            };
    }
}
