using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class SetText : MonoBehaviour
{
    public Object Object;

    private void Start()
        => GetComponent<TMP_Text>().SetText(Object.ToString());
}
