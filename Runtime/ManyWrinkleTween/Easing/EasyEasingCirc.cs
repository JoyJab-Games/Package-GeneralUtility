using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static partial class EasyEasing {
        
        public static float EaseCircIn(float x) => 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
        public static TweenHandle SetEaseCircIn(this TweenHandle info) => info.FuncWrapper(EaseCircIn);
        
        public static float EaseCircOut(float x) => Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
        public static TweenHandle SetEaseCircOut(this TweenHandle info) => info.FuncWrapper(EaseCircOut);
        
        public static float EaseCircInOut(float x) => x < 0.5
            ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2
            : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
        public static TweenHandle SetEaseCircInOut(this TweenHandle info) => info.FuncWrapper(EaseCircInOut);    }
}