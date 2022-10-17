using UnityEngine;

namespace CamExt
{
    public static class CamExtension
    {
        public static Ray MouseRay(this Camera cam)
            => cam.ScreenPointToRay(Input.mousePosition);

        public static Vector3 Forward(this Camera cam)
            => cam.transform.forward;

        /*
        public static void RenderOnly(this Camera cam, params string[] layers)
        {
            for
        }
        */
            
    }
}
