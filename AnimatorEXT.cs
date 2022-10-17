using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Zilla.EXT.AnimationEXT
{
    public static class AnimatorEXT
    {
        public static async UniTask PlayAsync(this Animator anim, string stateName, int layer = 0)
        {
            anim.Play(stateName, layer);
            await UniTask.Yield();
            await UniTask.Delay((int)(1000f * anim.GetCurrentAnimatorStateInfo(layer).length));
        }

        public static IEnumerator PlayCoroutine(this Animator anim, string stateName, int layer = 0)
        {
            anim.Play(stateName, layer);
            yield return null;
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(layer).length);
        }
    }
}
