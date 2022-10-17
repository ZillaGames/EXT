using UnityEngine;
using UnityEngine.AI;

namespace VectorExt
{
    public static class VectorExt
    {
        public static Vector3 LookDir(this Vector3 vec, Vector3 to)
            => (to - vec).normalized;
        public static Vector2 Abs(this Vector2 vec)
            => new Vector2(
                Mathf.Abs(vec.x),
                Mathf.Abs(vec.y));

        public static Vector2 AbsLimit(this Vector2 vec, Vector2 absLimit)
            => new Vector2
            (
                vec.x.AbsLimit(absLimit.x),
                vec.y.AbsLimit(absLimit.y)
            );

        public static Vector2 Perpendicular(this Vector2 vec, bool isClockwise = true)
            => new Vector2(vec.y, -vec.x) * (isClockwise ? 1 : -1);

        public static System.Func<Vector3> PosGetter(this Vector3 tr)
            => () => tr;
        public static float Abs(this float f)
            => Mathf.Abs(f);

        public static float Sign(this float f)
            => Mathf.Sign(f);

        public static float AbsLimit(this float f, float absLimit)
            => f.Sign() * Mathf.Min(f.Abs(), absLimit);

        public static Vector2 RandomPointNear(this Vector2 vec, float minDist, float maxDist)
        {
            var point = Random.insideUnitCircle;
            return (point * (maxDist - minDist) + point * -minDist);
        }

        public static float NegativeMagnitude(this Vector3 vector)
            => Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));

        public static float NegativeMagnitude(this Vector2 vector)
            => Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y));

        public static void Lerp(this Vector3 vector, Vector3 b, float t)
            => vector = Vector3.Lerp(vector, b, t);

        public static bool MinMaxBetween(this Vector2 minMax, float value)
            => minMax.x <= value && value <= minMax.y;

        public static Vector3 SampleOnNavMesh(this Vector3 pos, int areaMask = 1)
            => NavMesh.SamplePosition(pos, out var hit, 5f, areaMask)
                ? hit.position
                : throw new System.Exception($"Could not sample NavMesh position!");
    }
}
