using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParticlesExt
{
    public static class ParticlesExtension
    {
        public static void MoveTo(this ParticleSystem system, Vector3 position)
            => system.transform.position = position;
        public static void Play(this Dictionary<string, ParticleSystem> dict, string system)
            => dict[system].Play();
        public static void Stop(this Dictionary<string, ParticleSystem> dict, string system)
            => dict[system].Stop();
        public static void MoveTo(this Dictionary<string, ParticleSystem> dict, string system, Vector3 pos)
            => dict[system].MoveTo(pos);
    }

}
