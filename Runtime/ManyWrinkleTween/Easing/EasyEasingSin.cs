using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static partial class EasyEasing {
        
        public static float EaseSinIn(float x) => 1 - Mathf.Cos((x * Mathf.PI) / 2);
        public static TweenInfo SetEaseSinIn(this TweenInfo info) => info.FuncWrapper(EaseSinIn);
        public static float EaseSinOut(float x) => Mathf.Sin((x * Mathf.PI) / 2);
        public static TweenInfo SetEaseSinOut(this TweenInfo info) => info.FuncWrapper(EaseSinOut);
        public static float EaseSinInOut(float x) => -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
        public static TweenInfo SetEaseSinInOut(this TweenInfo info) => info.FuncWrapper(EaseSinInOut);
    }
}