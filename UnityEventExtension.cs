using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace UnityEventExt
{
    public static class UnityEventExtension
    {
        public static T InvokeAndReturn<T>(this UnityEvent<T> e, T value)
        {
            e?.Invoke(value);
            return value;
        }
        
        public static async Task WaitOne(this UnityEvent @event, int timeout = -1)
        {
            using var token = new CancellationTokenSource();
            @event.AddListener(token.Cancel);

            try
            {
                await Task.Delay(timeout, token.Token);
                throw new TimeoutException();
            }
            catch (TaskCanceledException) { }
            finally
            { @event.RemoveListener(token.Cancel); }
        }

        public static async Task<T> WaitOne<T>(this UnityEvent<T> @event, int timeout = -1)
        {
            T value = default(T);

            using var token = new CancellationTokenSource();
            var action = new UnityAction<T>(v => { value = v; token.Cancel(); });
            @event.AddListener(action);

            try
            {
                await Task.Delay(timeout, token.Token);
                throw new TimeoutException();
            }
            catch (TaskCanceledException) { return value; }

            finally { @event.RemoveListener(action); }
        }
    }
}