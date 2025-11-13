using System.Collections;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    
    public partial class ManyWrinkleTween {
        
        public static TweenInfo Value(float startValue, float targetValue, float duration) {
            return _instance.AddNewTween(duration, null, new Vector4(startValue, startValue), new Vector4(targetValue, targetValue), DoFuckAll);
        }

        public static TweenInfo Value(Vector3 startValue, Vector3 targetValue, float duration) {
            return _instance.AddNewTween(duration, null, startValue, targetValue, DoFuckAll);
        }
    }
}