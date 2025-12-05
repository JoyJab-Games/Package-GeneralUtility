using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    internal struct TweenInstance {
        public int Generation;
        /// <summary> True as long as the tween is still executing </summary>
        public bool Running;
        public Func<TweenInstance, float, ActionData> Function;
        
        public Transform Target;
        public Object OffbrandTarget;
        public Vector4 StartData;
        public Vector4 TargetData;
        public TweenTimer Timer;
        
        /// <summary> The Function defining the easing type </summary>
        public Func<float, float> Easing;
        
        /// <summary> The Action that will be invoked once the tween finishes executing </summary>
        internal GenericAction _onFinish;

        /// <summary> The Action that will be invoked every time the tween updates </summary>
        internal GenericAction _onUpdate;
        
        public TweenInstance(int generation, float duration, Object target, Vector4 startData, Vector4 targetData, Func<TweenInstance, float, ActionData> function) 
            : this(generation, duration, startData, targetData, function) {
            Target = null;
            OffbrandTarget = target;
        }
        public TweenInstance(int generation, float duration, Transform target, Vector4 startData, Vector4 targetData, Func<TweenInstance, float, ActionData> function)
            : this(generation, duration, startData, targetData, function) {
            Target = target;
            OffbrandTarget = null;
        }

        public TweenInstance(int generation, float duration, Vector4 startData, Vector4 targetData, Func<TweenInstance, float, ActionData> function) {
            Generation = generation;
            Running = true;
            Timer = new TweenTimer(duration);
            
            Target = null;
            OffbrandTarget = null;
            StartData = startData;
            TargetData = targetData;
            Function = function;
            
            Easing = x => x;
            _onFinish = new GenericAction();
            _onUpdate = new GenericAction();
        }
    }
}