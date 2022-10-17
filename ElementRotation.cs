using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRotation : MonoBehaviour
{
    [SerializeField, Range(0, 100)] float speed;

    private void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
