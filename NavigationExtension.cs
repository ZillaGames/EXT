using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace NavigationExt
{
    public static class NavigationExtension
    {
        public static async Task MoveTo(this NavMeshAgent agent, Vector3 position)
        {
            agent.SetDestination(position);
            while (agent.pathPending
                || agent.remainingDistance > agent.stoppingDistance)
                await Task.Yield();
        }

        /*
        public static void SetStats(this NavMeshAgent agent, NavAgentStats stats)
        {
            agent.speed = stats.Speed;
            agent.angularSpeed = stats.AngularSpeed;
            agent.acceleration = stats.Acceleration;
            agent.stoppingDistance = stats.StoppingDistance;
            agent.obstacleAvoidanceType = stats.ObstacleAvoidanceType;
        }
        */
    }

}
