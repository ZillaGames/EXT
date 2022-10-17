using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using static UnityEngine.Mathf;

namespace ColorExt
{
    public static class ColorExtension
    {
        public static float Hue(this Color c)
        {
            Color.RGBToHSV(c, out float h, out _, out _);
            return h;
        }

        static float HueDistance(float hue1, float hue2)
            => Min(Abs(hue1 - hue2), Abs(360 - (hue1 - hue2)));
        public static float Distance(this Color c, Color color)
            => HueDistance(c.Hue(), color.Hue());

        public static Color Mix(this Color c, Color color) => (c + color) * 0.5f;
    }
}
