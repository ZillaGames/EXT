using UnityEngine;

namespace RayExt
{
    public static class RayExtension
    {
        public static string Tag(this RaycastHit hit)
            => hit.transform.gameObject.tag;
    }
}
