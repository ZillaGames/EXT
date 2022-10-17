using UnityEngine;

namespace PlaneExt
{
    public static class PlaneExtension
    {
        public static bool Raycast(this Plane plane, Ray ray, out Vector3 point)
        {
            var b = plane.Raycast(ray, out float enter);
            point = ray.GetPoint(enter);
            return b;
        }
    }
}
