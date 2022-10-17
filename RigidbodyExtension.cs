using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RigidbodyExt
{
    public static class RigidbodyExtension
    {
        public static void Activate(this Rigidbody rb, bool detectCollisions = true)
        {
            rb.useGravity = true;
            rb.detectCollisions = detectCollisions;
        }

        public static void Deactivate(this Rigidbody rb, bool detectCollisions = false)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            rb.detectCollisions = detectCollisions;
        }

        public static void Configure(this Rigidbody body, float mass, float drag, float angularDrag, bool useGravity)
        {
            body.mass = mass;
            body.drag = drag;
            body.angularDrag = angularDrag;
            body.useGravity = useGravity;
        }
    }

}
