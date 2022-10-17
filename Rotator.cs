using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public const float MinAngle = 0.1f;
    public const float MaxDegreesDelta = 5f;

    public Quaternion LastAngle;

    public float DeltaAngle
    {
        get
        {
            var angle = Quaternion.Angle(transform.rotation, LastAngle);
            LastAngle = transform.rotation;
            return angle;
        }
    }

    public async Task RotateTowards(float angle)
        => await RotateTowards(Quaternion.Euler(0f, angle, 0f));
    public async Task RotateTowards(Vector3 focus)
        => await RotateTowards(Quaternion.LookRotation(focus - transform.position));

    public async Task RotateTowards(Quaternion qt)
    {
        while (Quaternion.Angle(transform.rotation, qt) > MinAngle)
        {
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, qt, MaxDegreesDelta);
            await Task.Yield();
        }
    }

}
