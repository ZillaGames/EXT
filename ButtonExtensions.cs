using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using TransformExtension;
using UnityEventExt;
using System.Threading.Tasks;

namespace ButtonExtensions
{
    public static class ButtonExtension
    {
        public static TMP_Text GetText(this Button button)
            => button.GetComponentInChildren<TMP_Text>();

        public static void SetLabel(this Button button, string text)
            => button.GetComponentInChildren<TMP_Text>().SetText(text);

        public static void AddListener(this Button button, UnityAction action)
            => button.onClick.AddListener(action);

        public static void SetAlpha(this Button button, float alpha)
        {
            Graphic element = button.GetText();

            if (element == null)
                element = button.image;

            if (element == null)
                return;

            element.color = new Color(element.color.r, element.color.g, element.color.b, alpha);
        }

        /*
        public static void Display(this Button button, IDisplayable displayable)
        {
            button.transform.Find("Texture").GetComponent<RawImage>().texture = displayable.Texture;
            button.transform.Find("Label").GetComponent<TMP_Text>().SetText(displayable.Label);
        }

        public static void Set(this Button @this, NewPopup.Button button)
        {
            @this.SetLabel(button.Label);
            @this.onClick.AddListener(button.Action);
        }

        public static Task WaitClick(this Button @this)
        {
            try { return @this.onClick.WaitOne(); }
            catch (ConnectionUtility.TimeoutException e)
            { throw e; }
        }
        */
    }
}