using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HingeExt
{
    public static class HingeExtension
    {
        public static void Configure(this HingeJoint hinge, Rigidbody connectBody)
        {
            hinge.connectedBody = connectBody;
            hinge.autoConfigureConnectedAnchor = true;
        }

        public static void Configure(this HingeJoint hinge, Rigidbody connectBody, Vector3 axis, Vector3 connectedAnchor, float connectMassScale)
        {
            hinge.connectedBody = connectBody;
            hinge.autoConfigureConnectedAnchor = false;
            hinge.axis = axis;
            hinge.connectedAnchor = connectedAnchor;
            hinge.connectedMassScale = connectMassScale;
        }
    }
}
