using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static partial class EasyEasing {
        
        public static float EaseCubicIn(float x) => Mathf.Pow(x, 3);
        public static TweenHandle SetEaseCubicIn(this TweenHandle info) => info.FuncWrapper(EaseCubicIn);
        
        public static float EaseCubicOut(float x) => 1 - Mathf.Pow(1 - x, 3);
        public static TweenHandle SetEaseCubicOut(this TweenHandle info) => info.FuncWrapper(EaseCubicOut);
        
        public static float EaseCubicInOut(float x) => x < 0.5 
            ? 4 * Mathf.Pow(x, 3)
            : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
        public static TweenHandle SetEaseCubicInOut(this TweenHandle info) => info.FuncWrapper(EaseCubicInOut);
    }
}