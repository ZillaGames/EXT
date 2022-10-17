using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Display item that updates its text component(TMPro) when <see cref="UpdateTextEvent"/> is called
/// </summary>
/// <typeparam name="T">Event argument type</typeparam>
[RequireComponent(typeof(TMP_Text))]
public abstract class HUDSync<T> : MonoBehaviour
{
    TMP_Text _text;

    /// <summary>
    /// Function that converts the object sent by the Event to a string, to be displayed afterwards
    /// </summary>
    /// <param name="type">Event argument type</param>
    /// <returns>String to be displayed on Text(TMPro) component</returns>
    protected abstract string GetText(T type);
    protected abstract UnityEvent<T> UpdateTextEvent { get; }
    

    void SetText(T type) => _text.SetText(GetText(type));
    protected virtual void Awake() => _text = GetComponent<TMP_Text>();

    private void OnEnable() => UpdateTextEvent.AddListener(SetText);

    private void OnDisable() => UpdateTextEvent.RemoveListener(SetText);
}
