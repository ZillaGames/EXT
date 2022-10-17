using UnityEngine;
using static UnityEngine.Mathf;

namespace Zilla.EXT.Utilities.Trigf
{
    public static class Trigf
    {
        public static void SinCos(float angle, out float sin, out float cos)
        {
            sin = Sin(angle * Deg2Rad);
            cos = Sqrt(1 - (sin * sin));
        }

        public static void SinCosTan(float angle, out float sin, out float cos, out float tan)
        {
            SinCos(angle, out sin, out cos);
            tan = sin / cos;
        }

        public static Vector2 AngleToDir(float angle, float magnitude = 1f)
        {
            SinCos(angle, out var sin, out var cos);
            return AngleToDir(sin, cos, magnitude);
        }

        public static Vector2 AngleToDir(float sin, float cos, float magnitude = 1f)
            => new Vector2(cos, sin) * magnitude;
    }
}