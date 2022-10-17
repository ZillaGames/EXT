using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
using System;

namespace Zilla.EXT.BoundsEXT
{
    public static class BoundsEXT
    {
        public static Bounds GetBounds(this IEnumerable<Bounds> bounds)
            => new Bounds(bounds.Center(), bounds.TotalSize());
        public static Vector3 TotalSize(this IEnumerable<Bounds> bounds)
            => bounds.Aggregate(
                Vector3.zero,
                (vec, b) => b.size + vec);

        public static Vector3 AvgSize(this IEnumerable<Bounds> bounds)
            => bounds.TotalSize() / bounds.Count();
        public static float MaxSize(this Bounds b)
            => Mathf.Max(b.size.x, b.size.y, b.size.z);
        public static Vector3 TotalSize(this IEnumerable<Bounds> bounds, Vector3 factor)
            => bounds.TotalSize() + factor * (bounds.Count() - 1);

        public static Vector3 Center(this IEnumerable<Bounds> bounds)
            => bounds.Aggregate(
                Vector3.zero,
                (vec, b) => b.center + vec)
            / bounds.Count();
        
        public static Bounds GetBounds(this GameObject obj)
            => obj.GetComponentInChildren<Renderer>().bounds;

        public static Bounds GetBounds(this Transform transform)
            => transform.gameObject.GetBounds();

        public static Vector3 PointInside(this Bounds bounds, Vector3 randomPoint)
            => bounds.min + Vector3.Scale(bounds.size, randomPoint);
        public static Vector3 RandomPointInside(this Bounds bounds)
            => PointInside(bounds, RandomUtility.Vector3);
        public static Vector3 RandomNavPointInside(this Bounds bounds, string navMeshArea)
            => NavMesh.SamplePosition(
                bounds.RandomPointInside(),
                out var hit,
                bounds.MaxSize(),
                NavMesh.GetAreaFromName(navMeshArea))
                    ? hit.position
                    : throw new Exception($"Could not find NavMesh point inside bound: {bounds}");
    }
}

