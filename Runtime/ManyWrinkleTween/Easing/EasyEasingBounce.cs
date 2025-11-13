namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public static partial class EasyEasing {
        
        private static float BounceFunction(float x) {
            const float n1 = 7.5625f;
            const float d1 = 2.75f;

            if (x < 1 / d1) return n1 * x * x;
            if (x < 2 / d1) return n1 * (x -= 1.5f / d1) * x + 0.75f;
            if (x < 2.5 / d1) return n1 * (x -= 2.25f / d1) * x + 0.9375f;
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
        
        public static float EaseBounceIn(float x) => 1 - BounceFunction(1 - x);
        public static TweenInfo SetEaseBounceIn(this TweenInfo info) => info.FuncWrapper(EaseBounceIn);
        
        public static float EaseBounceOut(float x) => BounceFunction(x);
        public static TweenInfo SetEaseBounceOut(this TweenInfo info) => info.FuncWrapper(EaseBounceOut);
        
        public static float EaseBounceInOut(float x) => x < 0.5
            ? (1 - BounceFunction(1 - 2 * x)) / 2
            : (1 + BounceFunction(2 * x - 1)) / 2;
        public static TweenInfo SetEaseBounceInOut(this TweenInfo info) => info.FuncWrapper(EaseBounceInOut);
    }
}