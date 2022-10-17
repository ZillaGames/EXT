using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomUtility
{
    static readonly System.Random Random = new System.Random();
    static float Value => (float)Random.NextDouble();
    public static Vector2 Vector2
        => new Vector2(Value, Value);
    public static Vector3 Vector3
        => new Vector3(Value, Value, Value);
    public static Quaternion WorldUpRot
        => Quaternion.Euler(0f, Value * 360f, 0f);

    public static bool FlipCoin(float winRatio)
        => Value <= winRatio;
}
