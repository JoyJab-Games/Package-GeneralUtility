using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static partial class EasyEasing {
        public static float EaseQuadIn(float x) => Mathf.Pow(x, 2);
        public static TweenHandle SetEaseQuadIn(this TweenHandle info) => info.FuncWrapper(EaseQuadIn);
        public static float EaseQuadOut(float x) => 1 - (1 - x) * (1 - x);
        public static TweenHandle SetEaseQuadOut(this TweenHandle info) => info.FuncWrapper(EaseQuadOut);
        public static float EaseQuadInOut(float x) => x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
        public static TweenHandle SetEaseQuadInOut(this TweenHandle info) => info.FuncWrapper(EaseQuadInOut);
    }
}