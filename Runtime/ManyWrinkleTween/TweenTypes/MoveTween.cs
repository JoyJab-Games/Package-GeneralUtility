using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween {
        
        public static TweenInfo Move(GameObject target, Vector3 targetPosition, float duration) 
            => Move(target.transform, targetPosition, duration);
        public static TweenInfo Move(Transform target, Vector3 targetPosition, float duration) {
            if(target == null) return null;
            Vector3 startPosition = target.position;
            return _instance.AddNewTween(duration, target, startPosition, targetPosition, ApplyMove);
        }

        private static void ApplyMove(TweenInstance instance, float progress) {
            Vector3 currentPosition = Vector3.LerpUnclamped(instance.StartData, instance.TargetData, progress);
            instance.Target.position = currentPosition;
        }
        
        public static TweenInfo Move(RectTransform target, Vector2 targetAnchored, float duration) {
            if(target == null) return null;
            Vector2 startPosition = target.anchoredPosition;
            return _instance.AddNewTween(duration, target, startPosition, targetAnchored, ApplyMoveRect);
        }
        private static void ApplyMoveRect(TweenInstance instance, float progress) {
            Vector3 currentPosition = Vector3.LerpUnclamped(instance.StartData, instance.TargetData, progress);
            ((RectTransform)instance.Target).anchoredPosition = currentPosition;
        }
    }
}