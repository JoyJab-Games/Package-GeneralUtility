using System;
using System.Collections;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween {
        
        public static TweenInfo DelayedCall(float duration, Action action) {
            TweenInfo info = _instance.AddNewTween(duration, null, Vector4.zero, Vector4.zero, DoFuckAll);
            info.SetOnFinish(action);
            return info;
        }

        private static void DoFuckAll(TweenInstance tweenInstance, float f) { }
    }
}