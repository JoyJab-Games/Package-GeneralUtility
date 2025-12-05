using UnityEngine;
using UnityEngine.UI;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween {

        public static TweenHandle BlendAlpha(CanvasGroup target, float newAlpha, float duration) {
            if (target == null) return TweenHandle.Invalid;
            return _instance.AddNewTween(duration, target, new Vector4(target.alpha, target.alpha), 
                new Vector4(newAlpha, newAlpha), DoBlendCanvas);
        }

        private static ActionData DoBlendCanvas(TweenInstance arg1, float arg2) {
            if(arg1.OffbrandTarget is not CanvasGroup group) return ActionData.Cancelled(arg2);
            group.alpha = Mathf.Lerp(arg1.StartData.x, arg1.TargetData.x, arg2);
            return ActionData.Progress(arg2); 
        }
        public static TweenHandle BlendAlpha(Graphic target, float newAlpha, float duration) {
            if (target == null) return TweenHandle.Invalid;
            return _instance.AddNewTween(duration, target, new Vector4(target.color.a, target.color.a), 
                new Vector4(newAlpha, newAlpha), DoBlendGraphic);
        }

        private static ActionData DoBlendGraphic(TweenInstance arg1, float arg2) {
            if(arg1.OffbrandTarget is not Graphic graphic) return ActionData.Cancelled(arg2);
            Color color = graphic.color;
            color.a = Mathf.Lerp(arg1.StartData.x, arg1.TargetData.x, arg2);
            graphic.color = color;
            return ActionData.Progress(arg2); 
        }
    }
}