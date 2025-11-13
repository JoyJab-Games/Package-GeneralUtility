using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static partial class EasyEasing {
        public static float EaseQuartIn(float x) => Mathf.Pow(x, 4);
        public static TweenInfo SetEaseQuartIn(this TweenInfo info) => info.FuncWrapper(EaseQuartIn);
        
        public static float EaseQuartOut(float x) => 1 - Mathf.Pow(1 - x, 4);
        public static TweenInfo SetEaseQuartOut(this TweenInfo info) => info.FuncWrapper(EaseQuartOut);
        
        public static float EaseQuartInOut(float x) => x < 0.5
            ? 8 * Mathf.Pow(x, 4)
            : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
        public static TweenInfo SetEaseQuartInOut(this TweenInfo info) => info.FuncWrapper(EaseQuartInOut);
    }
}