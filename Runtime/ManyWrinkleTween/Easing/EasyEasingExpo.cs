using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static partial class EasyEasing {
        
        public static float EaseExpoIn(float x) => EasyEasingUtil.Fallback0(x, () => Mathf.Pow(2, 10 * x - 10));
        public static TweenInfo SetEaseExpoIn(this TweenInfo info) => info.FuncWrapper(EaseExpoIn);
        
        public static float EaseExpoOut(float x) => EasyEasingUtil.Fallback1(x, () => 1 - Mathf.Pow(2, -10 * x));
        public static TweenInfo SetEaseExpoOut(this TweenInfo info) => info.FuncWrapper(EaseExpoOut);
        
        public static float EaseExpoInOut(float x) => EasyEasingUtil.Fallback01(x, () => x < 0.5
            ? Mathf.Pow(2, 20 * x - 10) / 2
            : (2 - Mathf.Pow(2, -20 * x + 10)) / 2);
        public static TweenInfo SetEaseExpoInOut(this TweenInfo info) => info.FuncWrapper(EaseExpoInOut);
    }
}