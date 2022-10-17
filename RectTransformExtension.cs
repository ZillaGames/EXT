using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static ScreenUtility;
namespace RectTransformExt
{
    public static class RectTransformExtension
    {
        public static Tween AppearFromBelow(this RectTransform @this, float duration)
            => @this.DOAnchorPos(Center, duration).From(@this.Below());

        public static Tween DisappearToBelow(this RectTransform @this, float duration)
            => @this.DOAnchorPos(@this.Below(), duration);

        public static Vector2 Below(this RectTransform @this)
            => new Vector2(0f, Bottom);
    }
}

