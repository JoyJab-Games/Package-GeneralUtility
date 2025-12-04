using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween {
        
        public static TweenHandle Scale(GameObject target, Vector3 targetScale, float duration) 
            => Scale(target.transform, targetScale, duration);
        public static TweenHandle Scale(Transform target, Vector3 targetScale, float duration) {
            if(target == null) return TweenHandle.Invalid;
            return _instance.AddNewTween(duration, target, target.localScale, targetScale, ApplyScale);
        }

        private static ActionData ApplyScale(TweenInstance instance, float progress) {
            if (instance.Target == null) return ActionData.Cancelled(progress);
            
            Vector3 currentScale = Vector3.LerpUnclamped(instance.StartData, instance.TargetData, progress);
            instance.Target.localScale = currentScale;
            return ActionData.Complex(progress, currentScale);
        }

    }
}