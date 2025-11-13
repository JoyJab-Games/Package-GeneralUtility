using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween {
        
        public static TweenInfo Scale(GameObject target, Vector3 targetScale, float duration) 
            => Scale(target.transform, targetScale, duration);
        public static TweenInfo Scale(Transform target, Vector3 targetScale, float duration) {
            if(target == null) return null;
            return _instance.AddNewTween(duration, target, target.localScale, targetScale, ApplyScale);
        }

        private static void ApplyScale(TweenInstance instance, float progress) {
            Vector3 currentScale = Vector3.LerpUnclamped(instance.StartData, instance.TargetData, progress);
            instance.Target.localScale = currentScale;
        }

    }
}