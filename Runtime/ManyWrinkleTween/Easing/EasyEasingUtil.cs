using System;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static class EasyEasingUtil {
        // fallback functions to return a value instead of computing the other one
        public static float Fallback0(float x, Func<float> otherValue) {
            if (Math.Abs(x) < 0.00001f) return 0;
            return otherValue();
        }
        
        public static float Fallback1(float x, Func<float> otherValue) {
            if (Math.Abs(x - 1) < 0.00001f) return 1;
            return otherValue();
        }
        
        public static float Fallback01(float x, Func<float> otherValue) {
            if (Math.Abs(x) < 0.00001f) return 0;
            if (Math.Abs(x - 1) < 0.00001f) return 1;
            return otherValue();
        }

    }
}