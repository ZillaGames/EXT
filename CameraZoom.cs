using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    float Distance;
    Ray ray = default;
    [SerializeField, Range(0f, 1f)] float _zoom;
    public float Zoom
    {
        get => _zoom;
        set
        {
            _zoom = value;
            transform.DOMove(Point, Speed).SetEase(Ease.InOutCirc);
        }
    }

    [SerializeField] float Speed;

    Vector3 Point => ray.GetPoint(_zoom * Distance);
    public void SetFocus(Renderer focus)
    {
        var closestPoint = focus.bounds.ClosestPoint(transform.position);
        ray = new Ray(transform.position, closestPoint - transform.position);
        Distance = Vector3.Distance(transform.position, closestPoint);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(ray);
        Gizmos.DrawWireSphere(Point, 0.1f);
    }
}
