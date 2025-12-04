using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween {
        
        public static TweenHandle Move(GameObject target, Vector3 targetPosition, float duration) 
            => Move(target.transform, targetPosition, duration);
        public static TweenHandle Move(Transform target, Vector3 targetPosition, float duration) {
            if (target == null) return TweenHandle.Invalid;
            Vector3 startPosition = target.position;
            return _instance.AddNewTween(duration, target, startPosition, targetPosition, ApplyMove);
        }

        private static ActionData ApplyMove(TweenInstance instance, float progress) {
            if (instance.Target == null) return ActionData.Cancelled(progress);
            
            Vector3 currentPosition = Vector3.LerpUnclamped(instance.StartData, instance.TargetData, progress);
            instance.Target.position = currentPosition;
            return ActionData.Complex(progress, currentPosition);
        }
        
        public static TweenHandle Move(RectTransform target, Vector2 targetAnchored, float duration) {
            if (target == null) return TweenHandle.Invalid;
            Vector2 startPosition = target.anchoredPosition;
            return _instance.AddNewTween(duration, target, startPosition, targetAnchored, ApplyMoveRect);
        }
        private static ActionData ApplyMoveRect(TweenInstance instance, float progress) {
            if (instance.Target == null) return ActionData.Cancelled(progress);
            
            Vector3 currentPosition = Vector3.LerpUnclamped(instance.StartData, instance.TargetData, progress);
            ((RectTransform)instance.Target).anchoredPosition = currentPosition;
            return ActionData.Complex(progress, currentPosition);
        }
    }
}