using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUtility : MonoBehaviour
{
    public static readonly int Bottom = -Screen.currentResolution.height/2;
    public static readonly int Right = Screen.currentResolution.width/2;
    public static int Width => Screen.currentResolution.width;
    public static int Height => Screen.currentResolution.height;

    public static readonly Vector2 Center = new Vector2(0f, 0f);
}
