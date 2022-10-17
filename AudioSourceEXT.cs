using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Zilla.EXT.AudioEXT
{
    public static class AudioSourceEXT
    {
        public static async UniTask Wait(this AudioClip clip)
            => await UniTask.Delay(1000 * (int)clip.length);
        public static async UniTask PlayAsync(this AudioSource source, AudioClip clip)
        {
            source.PlayOneShot(clip);
            await clip.Wait();
        }

        public static async UniTask PlayAsync(this AudioSource source, AudioClip clip, float volume)
        {
            source.PlayOneShot(clip, volume);
            await clip.Wait();
        }

        public static void SwitchClip(this AudioSource source, AudioClip clip, bool maintainTime = true)
        {
            var pos = source.time;
            source.clip = clip;
            if (maintainTime) source.time = pos % clip.length;
            source.Play();
        }

        public static void CopyAudioTo(this AudioSource from, AudioSource to)
            => (from.clip, from.time, from.pitch, from.volume)
                = (to.clip, to.time, to.pitch, to.volume);

        public static void SwitchMusic(this AudioSource @this, AudioSource auxSource, AudioClip music, bool keepTime, float duration, float delay = 0f, Ease ease = Ease.InOutCubic)
        {
            auxSource.DOComplete(); @this.DOComplete();

            auxSource.enabled = true;
            @this.CopyAudioTo(auxSource);
            @this.clip = music;
            if (keepTime) @this.time = auxSource.time % @this.clip.length;

            auxSource.DOVolume(0f, duration).OnComplete(() => auxSource.enabled = false).SetEase(ease);
            @this.DOVolume(0f, duration).From().SetDelay(delay).SetEase(ease);
        }

        public static Tweener DOVolume(this AudioSource @this, float volume, float duration)
            => DOTween.To(() => @this.volume, v => @this.volume = v, volume, duration);
    }

}
