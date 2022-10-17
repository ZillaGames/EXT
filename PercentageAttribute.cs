using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class PercentageAttribute : Attribute
{
    public float Min, Max;
    public PercentageAttribute(float min = 0, float max = 100)
    {
        Min = min;
        Max = max;
    }
}
