using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NavMeshExt
{
    public static class NavMeshExtension
    {
        public static Mesh ToMesh(this NavMeshTriangulation navMesh)
        {
            var mesh = new Mesh() { vertices = navMesh.vertices };
            mesh.SetIndices(navMesh.indices, MeshTopology.Triangles, 0);
            return mesh;
        }
    }

}