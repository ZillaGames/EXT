using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public abstract class HUDUpdateSync : MonoBehaviour
{
    TMP_Text _text;
    WaitForSecondsRealtime _wait;

    protected abstract float UpdateInterval { get; }
    protected abstract string GetText();

    
    private void OnEnable() => StartCoroutine(WaitCoroutine());

    private void OnDisable() => StopAllCoroutines();
    protected virtual void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _wait = new WaitForSecondsRealtime(UpdateInterval);
    }
    IEnumerator WaitCoroutine()
    {
        while(true)
        {
            _text.SetText(GetText());
            yield return _wait;
        }
    }

    private void OnValidate()
        => _wait = new WaitForSecondsRealtime(UpdateInterval);
}
