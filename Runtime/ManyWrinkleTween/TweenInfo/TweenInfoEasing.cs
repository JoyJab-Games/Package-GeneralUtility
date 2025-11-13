using System;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class TweenInfo {

        /// <summary> The Function defining the easing type </summary>
        public Func<float, float> Easing { get; private set; } = x => x;
        
        //just a collection of math stolen from https://easings.net/#
        public TweenInfo SetEaseLinear() => FuncWrapper(x => x);
        public TweenInfo SetCustomEase(AnimationCurve curve) => FuncWrapper(curve.Evaluate);

        /// <summary> utility function to set the easing and return the info object for chaining syntax </summary>
        internal TweenInfo FuncWrapper(Func<float, float> function) {
            Easing = function;
            return this;
        }

    }
}