using UnityEngine;

public class CheckHelper
{
    public static bool RunCheck(float chance)
    {
        return Random.value < chance;
    }
}