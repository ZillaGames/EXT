using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    private static object m_Lock = new object();
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    public void Awake()
    {
        if (_instance == null)
        {
            lock (m_Lock)
            {
                if (_instance == null)
                {
                    _instance = this as T;
                }
            }
        }
        else
        {
            Destroy(this);
        }
    }
}