using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween {
        public static TweenHandle Rotate(Transform target, Quaternion targetRotation, float duration) {
            if(target == null) return TweenHandle.Invalid;
            Vector4 startPosition = new (target.rotation.x, target.rotation.y, target.rotation.z, target.rotation.w);
            Vector4 targetPosition = new (targetRotation.x, targetRotation.y, targetRotation.z, targetRotation.w);
            return _instance.AddNewTween(duration, target, startPosition, targetPosition, ApplyRotation);
        }

        private static ActionData ApplyRotation(TweenInstance instance, float progress) {
            if (instance.Target == null) return ActionData.Cancelled(progress);
            
            Quaternion from = new(instance.StartData.x, instance.StartData.y, instance.StartData.z, instance.StartData.w);
            Quaternion to = new(instance.TargetData.x, instance.TargetData.y, instance.TargetData.z, instance.TargetData.w);
            instance.Target.rotation = Quaternion.LerpUnclamped(from, to, progress);
            return ActionData.Complex(progress, instance.Target.rotation.eulerAngles);
        }

        public static TweenHandle RotateLocal(Transform target, Quaternion targetRotation, float duration) {
            if(target == null) return TweenHandle.Invalid;
            Vector4 startPosition = new (target.localRotation.x, target.localRotation.y, target.localRotation.z, target.localRotation.w);
            Vector4 targetPosition = new (targetRotation.x, targetRotation.y, targetRotation.z, targetRotation.w);
            return _instance.AddNewTween(duration, target, startPosition, targetPosition, ApplyRotationLocal);
        }

        private static ActionData ApplyRotationLocal(TweenInstance instance, float progress) {
            if (instance.Target == null) return ActionData.Cancelled(progress);
            
            Quaternion from = new(instance.StartData.x, instance.StartData.y, instance.StartData.z, instance.StartData.w);
            Quaternion to = new(instance.TargetData.x, instance.TargetData.y, instance.TargetData.z, instance.TargetData.w);
            instance.Target.localRotation = Quaternion.LerpUnclamped(from, to, progress);
            return ActionData.Complex(progress, instance.Target.localRotation.eulerAngles);
        }

    }
}