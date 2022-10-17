using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using QuaternionExt;
using DG.Tweening;
using System.Threading.Tasks;
using static UnityEngine.Random;
using Swizzler;
using UnityEngine.AI;

namespace TransformExtension
{
    public static class TransformExtension
    {
        public static Ray ForwardRay(this Transform tr)
            => new Ray(tr.position, tr.forward);
        public static bool CastRay(this Transform tr, out RaycastHit hit, float maxDistance)
            => Physics.Raycast(tr.ForwardRay(), out hit, maxDistance);
        public static IEnumerable<Transform> Children(this Transform tr)
            => tr.Cast<Transform>();

        public static Vector3 RandomPos(this Transform tr, float minDist, float maxDist, float maxAngle)
            => tr.position +
            Quaternion.Euler(0.0f, Range(-maxAngle, maxAngle), 0.0f)
                * tr.forward * Range(minDist, maxDist);

        public static Vector3 RandomPos(this Transform tr, Vector3 forward, float minDist, float maxDist, float maxAngle)
            => tr.position +
            Quaternion.Euler(0.0f, Range(-maxAngle, maxAngle), 0.0f)
                * forward * Range(minDist, maxDist);
        public static void LookTowardsDir(this Transform tr, Vector3 desiredDir, float lerpValue, out float distance)
        {
            var newValue = Vector3.Lerp(tr.forward, desiredDir, lerpValue);
            distance = (newValue - desiredDir).magnitude;
        }
        public static IEnumerable<GameObject> ChildrenObject(this Transform tr)
            => tr.Children().Select(t => t.gameObject);

        /*
        public static IEnumerable<Bounds> ChildrenBounds(this Transform tr)
            => tr.Children().Select(t => t.GetBounds());

        public static void LayoutObject(this Transform tr, Vector3 factor, Vector3 initial)
        {
            if (tr.childCount == 1) return;
            int i = 0;
            var avgSize = tr.ChildrenBounds().AvgSize();
            var spacing = Vector3.Scale(factor, avgSize);
            initial.Scale(avgSize);

            foreach (var t in tr.Children())
                t.position = initial + i++ * spacing;
        }
        */

        public static bool LookAt(this Transform tr, Vector3 pos, float yLimit)
        {
            var lookRot = Quaternion.LookRotation(pos - tr.localPosition);
            var insideLimits = Mathf.Abs(lookRot.YAngle()) < yLimit;

            return insideLimits;
        }

        public static void ClearChildren(this Transform transform)
        {
            foreach (Transform child in transform)
                Object.Destroy(child.gameObject);
        }

        public static IEnumerable<T> GetChildrenComponents<T>(this Transform transform) where T : Component
            => transform.Children().Select(t => t.GetComponent<T>());
        
        public static Sequence DOMoveAndRotate(this Transform @this, Transform to, float duration)
            => DOMoveAndRotate(@this, to.position, to.rotation, duration);

        public static Sequence DOMoveAndRotate(this Transform @this, (Vector3 pos, Quaternion rot) posRot, float duration)
            => DOMoveAndRotate(@this, posRot.pos, posRot.rot, duration);
        public static Sequence DOMoveAndRotate(this Transform @this, Vector3 pos, Quaternion rot, float duration)
            => DOTween.Sequence()
                .Insert(0, @this.DOMove(pos, duration))
                .Insert(0, @this.DORotateQuaternion(rot, duration));

        public static void SetPositionAndRotation(this Transform @this, Vector3 position, Vector3 forward, Vector3 normal)
            => @this.SetPositionAndRotation(position,
                Quaternion.LookRotation(forward, normal));

        public static void SetPositionAndRotation(this Transform @this, (Vector3 pos, Quaternion rot) posRot)
            => @this.SetPositionAndRotation(posRot.pos, posRot.rot);
        public static void Set(this Transform @this, Transform to)
            => @this.SetPositionAndRotation(to.position, to.rotation);

        public static void Set(this Transform @this, GameObject to)
            => Set(@this, to.transform);

        public static IEnumerable<Transform> GetAllChildren(this Transform @this)
            => @this.GetComponentsInChildren<Transform>();

        public static Transform FindInAllChildren(this Transform @this, params string[] names)
            => @this.GetAllChildren().FirstOrDefault(t => names.Any(t.name.Equals));

        public static Vector2 Forward2D(this Transform tr)
            => tr.forward.X0Z().normalized;

        public static T AddChildComponent<T>(this Transform tr, string name) where T : Component
        {
            var obj = new GameObject(name, typeof(T)).GetComponent<T>();
            obj.transform.SetParent(tr);
            return obj;
        }

        public static T Find<T>(this Transform tr, string name) where T : Component
            => tr.Find(name).GetComponent<T>();
        public static bool TryFind(this Transform tr, string name, out Transform transform)
        {
            transform = tr.Find(name);
            return transform != null;
        }

        public static bool TryFind<T>(this Transform transform, string name, out T component) where T : Component
        {
            component = null;
            if (!transform.TryFind(name, out var tr)) return false;
            component = tr.GetComponent<T>();
            return component != null;
            
        }
        
    }

}