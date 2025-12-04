using System.Collections;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    
    public partial class ManyWrinkleTween {
        
        public static TweenHandle Value(float startValue, float targetValue, float duration) {
            return _instance.AddNewTween(duration, null, new Vector4(startValue, startValue), new Vector4(targetValue, targetValue), LerpProgress);
        }

        public static TweenHandle Value(Vector3 startValue, Vector3 targetValue, float duration) {
            return _instance.AddNewTween(duration, null, startValue, targetValue, LerpProgressVector3);
        }
        
        
        private static ActionData LerpProgress(TweenInstance tweenInstance, float f) {
            return ActionData.Progress(Mathf.Lerp(tweenInstance.StartData.x, tweenInstance.TargetData.x, f));
        }
        private static ActionData LerpProgressVector3(TweenInstance tweenInstance, float f) {
            return new ActionData() { Data = Vector3.Lerp(tweenInstance.StartData, tweenInstance.TargetData, f)};
        }
    }
}