using UnityEngine;

public static class Physf
{
    public static float Gravity => Physics.gravity.magnitude;
    public static float HalfGravity => Gravity * .5f;
    public static Vector3 Up => -Physics.gravity.normalized;
}
