using System;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    internal struct TweenInstance {
        public TweenInfo Info;
        public Action<TweenInstance, float> Function;
        public Transform Target;
        public Vector4 StartData;
        public Vector4 TargetData;
        public TweenTimer Timer;
        
        public TweenInstance(TweenInfo info, float duration, Transform target, Vector4 startData, Vector4 targetData, Action<TweenInstance, float> function) {
            Info = info;
            Timer = new TweenTimer(info, duration);
            Target = target;
            StartData = startData;
            TargetData = targetData;
            Function = function;
        }
    }
}