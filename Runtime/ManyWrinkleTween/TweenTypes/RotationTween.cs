using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween {
        public static TweenInfo Rotate(Transform target, Quaternion targetRotation, float duration) {
            if(target == null) return null;
            Vector4 startPosition = new (target.rotation.x, target.rotation.y, target.rotation.z, target.rotation.w);
            Vector4 targetPosition = new (targetRotation.x, targetRotation.y, targetRotation.z, targetRotation.w);
            return _instance.AddNewTween(duration, target, startPosition, targetPosition, ApplyRotation);
        }

        private static void ApplyRotation(TweenInstance instance, float progress) {
            Quaternion from = new(instance.StartData.x, instance.StartData.y, instance.StartData.z, instance.StartData.w);
            Quaternion to = new(instance.TargetData.x, instance.TargetData.y, instance.TargetData.z, instance.TargetData.w);
            instance.Target.rotation = Quaternion.LerpUnclamped(from, to, progress);
        }

        public static TweenInfo RotateLocal(Transform target, Quaternion targetRotation, float duration) {
            if(target == null) return null;
            Vector4 startPosition = new (target.localRotation.x, target.localRotation.y, target.localRotation.z, target.localRotation.w);
            Vector4 targetPosition = new (targetRotation.x, targetRotation.y, targetRotation.z, targetRotation.w);
            return _instance.AddNewTween(duration, target, startPosition, targetPosition, ApplyRotationLocal);
        }

        private static void ApplyRotationLocal(TweenInstance instance, float progress) {
            Quaternion from = new(instance.StartData.x, instance.StartData.y, instance.StartData.z, instance.StartData.w);
            Quaternion to = new(instance.TargetData.x, instance.TargetData.y, instance.TargetData.z, instance.TargetData.w);
            instance.Target.localRotation = Quaternion.LerpUnclamped(from, to, progress);
        }

    }
}