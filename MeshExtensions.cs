using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using System.Linq;
using DG.Tweening;
using System;

namespace MeshExtensions
{
    public static class MeshExtensions
    {
        public static List<SkinnedMeshRenderer> MeshInChildren(this IEnumerable<GameObject> objs)
            => objs.Aggregate(
                new List<SkinnedMeshRenderer>(),
                (list, mesh) =>
                { 
                    list.Add(mesh.GetComponentInChildren<SkinnedMeshRenderer>());
                    return list;
                });

        public static int Tris(this Mesh mesh)
            => mesh.triangles.Length;
        public static int Tris(this SkinnedMeshRenderer renderer)
            => renderer.sharedMesh.Tris();

        public static int Tris(this IEnumerable<Mesh> meshes)
            => meshes.Aggregate(0, (count, mesh) => count + mesh.Tris());
        public static int Tris(this IEnumerable<SkinnedMeshRenderer> renderers)
            => renderers.Aggregate(0, (count, mesh) => count + mesh.Tris());

        public static int BoneCount(this SkinnedMeshRenderer renderer)
            => renderer.bones.Length;
        public static int BoneCount(this IEnumerable<SkinnedMeshRenderer> renderers)
            => renderers.Aggregate(0, (count, mesh) => mesh.BoneCount());

        public static int BlendShapeCount(this SkinnedMeshRenderer renderer)
            => renderer.sharedMesh.blendShapeCount;

        public static long MemorySize(this SkinnedMeshRenderer renderer)
            => Profiler.GetRuntimeMemorySizeLong(renderer.sharedMesh);

        public static long MemorySize(this IEnumerable<SkinnedMeshRenderer> renderers)
            => renderers.Aggregate(0L, (l, mesh) => l + mesh.MemorySize());

        public static void SetMaterial(this IEnumerable<SkinnedMeshRenderer> renderers, Material m)
        {
            foreach (var r in renderers) r.material = m;
        }

        public static string GetInfo(this SkinnedMeshRenderer renderer)
            => $"{renderer.Tris()} Tris\n" +
               $"{renderer.BoneCount()} Bones\n" +
               $"{renderer.sharedMesh.blendShapeCount} BlendShapes\n" +
               $"{renderer.MemorySize() / 1000f : .00} KBs";

        public static string GetInfo(this IEnumerable<SkinnedMeshRenderer> renderers)
            =>  $"{renderers.Tris()} Tris\n" +
                $"{renderers.BoneCount()} Bones\n" +
                $"{renderers.First().BlendShapeCount()} BlendShapes\n" +
                $"{renderers.MemorySize() / 1000f : .00} KBs";

        public static Tweener DOBlendShape(this SkinnedMeshRenderer mesh, int index, float to, float duration)
            => DOTween.To(
                () => mesh.GetBlendShapeWeight(index),
                value => mesh.SetBlendShapeWeight(index, value),
                to, duration);

        public static int GetTotalIndiceCount(this Mesh mesh)
        {
            int count = 0;
            for(int i = 0; i < mesh.subMeshCount; i++)
                count += mesh.GetSubMesh(i).indexCount;

            return count;
        }

        public static int[] GetAllIndices(this Mesh mesh)
        {
            var indices = new List<int>();
            for (int i = 0; i < mesh.subMeshCount; i++)
                indices.AddRange(mesh.GetIndices(i));

            return indices.ToArray();
        }

        public static Vector3 GetCenter(this Mesh mesh)
            => mesh.bounds.center;

    }
}
