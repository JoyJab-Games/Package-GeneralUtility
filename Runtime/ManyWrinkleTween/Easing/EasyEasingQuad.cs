using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static partial class EasyEasing {
        public static float EaseQuadIn(float x) => Mathf.Pow(x, 2);
        public static TweenInfo SetEaseQuadIn(this TweenInfo info) => info.FuncWrapper(EaseQuadIn);
        public static float EaseQuadOut(float x) => 1 - (1 - x) * (1 - x);
        public static TweenInfo SetEaseQuadOut(this TweenInfo info) => info.FuncWrapper(EaseQuadOut);
        public static float EaseQuadInOut(float x) => x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
        public static TweenInfo SetEaseQuadInOut(this TweenInfo info) => info.FuncWrapper(EaseQuadInOut);
    }
}