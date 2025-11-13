using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static partial class EasyEasing {
        public static float EaseQuintIn(float x) => Mathf.Pow(x, 5);
        public static TweenInfo SetEaseQuintIn(this TweenInfo info) => info.FuncWrapper(EaseQuintIn);
        
        public static float EaseQuintOut(float x) => 1 - Mathf.Pow(1 - x, 5);
        public static TweenInfo SetEaseQuintOut(this TweenInfo info) => info.FuncWrapper(EaseQuintOut);
        
        public static float EaseQuintInOut(float x) => x < 0.5
            ? 16 * Mathf.Pow(x, 5)
            : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
        public static TweenInfo SetEaseQuintInOut(this TweenInfo info) => info.FuncWrapper(EaseQuintInOut);
    }
}