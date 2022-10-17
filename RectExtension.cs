using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RectExt
{
    public static class RectExtension
    {
        public static Rect Offset(this Rect rect, float x, float y)
            => new Rect(
                rect.x + x,
                rect.y + y,
                rect.width,
                rect.height);

        public static RectInt ToRectInt(this Rect rect)
            => new RectInt((int)rect.xMin, (int)rect.yMin, (int)rect.width, (int)rect.height);
    }

}
