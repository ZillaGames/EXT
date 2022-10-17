using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Input;
using System;

public class InputHelper : Singleton<InputHelper>
{
    public enum Mode { Touch, Mouse }
    delegate bool InputFunc(out Vector3 vec);

    public static UnityEvent<Vector3> OnInput
        = new UnityEvent<Vector3>();

    [SerializeField] Mode _mode;
    InputFunc Input;

    private void Update()
    {
        if (GetMouseButton(0))
            OnInput?.Invoke(mousePosition);
    }

    static bool MouseInput(out Vector3 mouse)
    {
        mouse = GetMouseButton(0) ? mousePosition : default;
        return mouse != default;
    }

    static bool TouchInput(out Vector3 touch)
    {
        touch = touchCount > 0 ? GetTouch(0).position : default;
        return touch != default;
    }

    void SetInput(Mode mode)
    {
        switch (_mode = mode)
        {
            case Mode.Touch: Input = TouchInput; return;
            case Mode.Mouse: Input = MouseInput; return;
        }
    }

}
