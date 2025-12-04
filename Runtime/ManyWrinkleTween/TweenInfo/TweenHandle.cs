using System;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public struct TweenHandle {

        internal int Index;
        internal int Generation;
        
        internal TweenHandle(int index, int generation) {
            Index = index;
            Generation = generation;
        }
        
        public static TweenHandle Invalid => new TweenHandle(-1, -1);

        public TweenHandle SetOnUpdate(Action onUpdate) => SetOnUpdate(new GenericAction(onUpdate));
        public TweenHandle SetOnUpdate(Action<float> onUpdate) => SetOnUpdate(new GenericAction(onUpdate));
        public TweenHandle SetOnUpdate(Action<Vector3> onUpdate) => SetOnUpdate(new GenericAction(onUpdate));
        private TweenHandle SetOnUpdate(GenericAction action) {
            if (!ManyWrinkleTween.IsValidHandle(this)) return this;
            ref TweenInstance info = ref ManyWrinkleTween.TryGetTween(this);
            info._onUpdate = action;
            return this;
        }

        public TweenHandle SetOnFinish(Action onFinish) => SetOnFinish(new GenericAction(onFinish));
        public TweenHandle SetOnFinish(Action<float> onFinish) => SetOnFinish(new GenericAction(onFinish));
        public TweenHandle SetOnFinish(Action<Vector3> onFinish) => SetOnFinish(new GenericAction(onFinish));
        private TweenHandle SetOnFinish(GenericAction action) {
            if (!ManyWrinkleTween.IsValidHandle(this)) return this;
            ref TweenInstance info = ref ManyWrinkleTween.TryGetTween(this);
            info._onFinish = action;
            return this;
        }

        public TweenHandle SetLoopPingPong(int loopCount) => SetLoop(loopCount, true);
        public TweenHandle SetLoop(int loopCount) => SetLoop(loopCount, false);
        public TweenHandle SetLoop(int loopCount, bool pingPong) {
            if (!ManyWrinkleTween.IsValidHandle(this)) return this;
            ref TweenInstance info = ref ManyWrinkleTween.TryGetTween(this);
            ref TweenTimer timer = ref info.Timer;
            timer.LoopCount = loopCount + 1;
            timer.PingPong = pingPong;
            return this;
        }
        
        
        //just a collection of math stolen from https://easings.net/#
        public TweenHandle SetEaseLinear() => FuncWrapper(x => x);
        public TweenHandle SetCustomEase(AnimationCurve curve) => FuncWrapper(curve.Evaluate);

        /// <summary> utility function to set the easing and return the info object for chaining syntax </summary>
        internal TweenHandle FuncWrapper(Func<float, float> function) {
            if (!ManyWrinkleTween.IsValidHandle(this)) return this;
            ref TweenInstance info = ref ManyWrinkleTween.TryGetTween(this);
            info.Easing = function;
            return this;
        }
    }
}