using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public abstract class UIElement : MonoBehaviour
{
    protected abstract Sequence Sequence { get; }

    private void OnEnable()
        => Sequence.PlayForward();

    private void OnDisable()
        => Sequence.PlayBackwards();
}