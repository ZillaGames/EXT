using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpringMoveExt
{
    public static class SpringMovementExtension
    {
        public static void SpringMoveTowards(
            this Rigidbody body,
            Vector3 target,
            float dampness)
            => body.MovePosition(GetSprintPosition(
                body.position, target, body.velocity,
                dampness, Time.deltaTime));

        public static void SpringMoveTowards(
            this Rigidbody body,
            Vector3 target,
            float dampness,
            float maxSpeed)
            => body.MovePosition(GetSprintPosition(
                body.position, target, body.velocity,
                dampness, Time.deltaTime, maxSpeed));

        public static void SpringMoveTowards(
            this Transform tr,
            Vector3 target,
            Vector3 velocity,
            float dampness)
            => tr.position = GetSprintPosition(
                    tr.position, target, velocity,
                    dampness, Time.deltaTime);

        public static void SpringMoveTowards(
            this Vector3 vec,
            Vector3 target,
            Vector3 velocity,
            float dampness)
            => vec = GetSprintPosition(
                    vec, target, velocity,
                    dampness, Time.deltaTime);
        static Vector3 GetSprintPosition(
            Vector3 pos, Vector3 target,
            Vector3 velocity, float damp,
            float dt)
        {
            var n1 = velocity - (pos - target) * damp * damp * dt;
            var n2 = 1 + damp * dt;
            return pos + dt * n1 / (n2 * n2);
        }

        static Vector3 GetSprintPosition(
            Vector3 pos, Vector3 target,
            Vector3 velocity, float damp,
            float dt, float maxSpeed)
            => Vector3.ClampMagnitude(
                GetSprintPosition(pos, target, velocity, damp, dt),
                maxSpeed);
        
    }
}