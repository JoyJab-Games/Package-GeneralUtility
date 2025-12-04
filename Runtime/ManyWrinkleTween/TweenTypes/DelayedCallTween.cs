using System;
using System.Collections;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween {
        
        public static TweenHandle DelayedCall(float duration, Action action) {
            TweenHandle info = _instance.AddNewTween(duration, null, Vector4.zero, Vector4.zero, DoFuckAll);
            info.SetOnFinish(action);
            return info;
        }

        private static ActionData DoFuckAll(TweenInstance tweenInstance, float f) {
            return ActionData.Progress(f);
        }
    }
}