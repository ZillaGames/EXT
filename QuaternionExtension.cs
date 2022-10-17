using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QuaternionExt
{
    public static class QuaternionExtension
    {
        public static float XAngle(this Quaternion q)
            => q.w / q.x;
        public static float YAngle(this Quaternion q)
            => q.w / q.y;
        public static float ZAngle(this Quaternion q)
            => q.w / q.z;
    }

}
