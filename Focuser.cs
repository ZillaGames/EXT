using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using System;
using VectorExt;
using TransformExtension;

public class Focuser : MonoBehaviour
{
    Func<Vector3> Getter;
    public Vector3 Target
    {
        get => Getter.Invoke();
        set => Getter = value.PosGetter();
    }

    public Vector3 DesiredDirection
        => transform.position.LookDir(Getter.Invoke());
    public Vector3 LookDir
        => transform.forward;
    public float Distance;
    public float MinUpdateDistance;
    public float LerpSpeed;
    public UnityAction Action;

    private void LateUpdate()
    {
        transform.LookTowardsDir(DesiredDirection, LerpSpeed, out Distance);
    }
   
}
