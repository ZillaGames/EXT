using System;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

namespace CanvasExtensions
{
    public static class CanvasExtension
    {
        public static Tween Enable(this CanvasGroup canvas, float fadeTime)
        {
            canvas.gameObject.SetActive(true);
            canvas.blocksRaycasts = true;
            canvas.interactable = true;
            return canvas.DOFade(1f, fadeTime);
        }

        public static Tween Disable(this CanvasGroup canvas, float fadeTime)
        {
            canvas.blocksRaycasts = false;
            canvas.interactable = false;
            return canvas.DOFade(0f, fadeTime).From(1f).OnComplete(() => canvas.gameObject.SetActive(false));
        }

        public static void Disable(this CanvasGroup canvas)
        {
            canvas.alpha = 0;
            canvas.blocksRaycasts = false;
            canvas.interactable = false;
            canvas.gameObject.SetActive(false);
        }

        public static void Enable(this CanvasGroup canvas)
        {
            canvas.alpha = 1;
            canvas.blocksRaycasts = true;
            canvas.interactable = true;
            canvas.gameObject.SetActive(true);
        }
    }
}
