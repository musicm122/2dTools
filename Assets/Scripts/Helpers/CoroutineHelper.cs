using UnityEngine;
using System.Collections;
using System;

namespace Helpers
{
    public static class CoroutineHelper
    {
        public static IEnumerator DeferredExecutor<T>(float waitDuration, T obj, Action<T> onComplete)
        {
            yield return new WaitForSeconds(waitDuration);
            onComplete(obj);
        }

        public static IEnumerator DeferredExecutor(float waitDuration, Action onComplete)
        {
            yield return new WaitForSeconds(waitDuration);
            onComplete();
        }

        public static IEnumerator DeferredExecutorByFixedUpdate(Action onComplete)
        {
            yield return new WaitForFixedUpdate();
            onComplete();
        }

        public static IEnumerator DeferredExecutorByEndOfFrame(Action onComplete)
        {
            yield return new WaitForEndOfFrame();
            onComplete();
        }
    }
}