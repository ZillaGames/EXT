using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using static UnityEngine.Physics;
using RayExt;
using CamExt;

public class Raycaster : Singleton<Raycaster>
{
    public const float MaxDistance = 80f;

    public static UnityEvent<RaycastHit> OnHit = new UnityEvent<RaycastHit>();
    public static UnityEvent<Ray> OnNoHit = new UnityEvent<Ray>();

    public static UnityEvent OnPetSpotDown = new UnityEvent();
    public static UnityEvent OnPetSpotUp = new UnityEvent();


    public static UnityEvent OnPointerUp = new UnityEvent();

    [SerializeField] GameObject Spawn;
    static Camera Cam => Camera.main;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            ClickCast();

        else if (Input.GetMouseButtonUp(0))
            OnPointerUp?.Invoke();

        if (Input.GetMouseButtonDown(1))
            SpawnObjectAt(Input.mousePosition);
    }

    public static void Cast(Ray ray, float maxDistance = MaxDistance)
    {
        //Touchscreen.current.position.ReadValue();

        /*
        if(!Raycast(ray, out LastHit, maxDistance))
        {
            LastHit = LastHit == PointerInfo.NoHit
        }


        OnHit?.Invoke(hit);
        var tag = hit.transform.gameObject.tag;

        switch(tag)
        {
            case GroundTag:
                if (LastTag == PettingSpotTag)
                    OnPetSpotUp?.Invoke();
                break;
            case PettingSpotTag:
                if (LastTag != tag) OnPetSpotDown?.Invoke();
                OnPetSpotHit?.Invoke(hit, hit.transform.GetComponent<PettingSpotComponent>());
                break;
            default:
                if (LastTag == PettingSpotTag)
                    OnPetSpotUp?.Invoke();
                break;
        }

        LastTag = tag;
        */
    }

    public static void ClickCast(float maxDistance = MaxDistance)
        => Cast(Camera.main.MouseRay(), maxDistance);

    public static void SpawnObjectAt(Vector3 mousePosition)
    {
        var ray = Cam.ScreenPointToRay(mousePosition);

        if (!Raycast(ray, out RaycastHit hit)) return;

        Instantiate(Instance.Spawn, hit.point, Quaternion.identity);
    }

}