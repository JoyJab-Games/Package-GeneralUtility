using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class SmoothBrainTween {
        
        public static TweenInfo Move(GameObject gameObject, Vector3 targetPosition, float duration) {
            if(gameObject == null) return null ;
            TweenInfo info = new TweenInfo();

            Vector3 startPosition = gameObject.transform.position;
            
            Coroutine routine = _instance.StartCoroutine(
                GenericTweenRoutineCoroutine(info, duration, null ,
                    progress => ApplyMove(progress, gameObject, startPosition, targetPosition),
                    progress => ApplyMove(progress, gameObject, startPosition, targetPosition),
                    customVecValue: f => Vector3.Lerp(startPosition, targetPosition, f)));

            _instance.AddNewTween(info, routine);
            return info;
        }

        private static void ApplyMove(float progress, GameObject gameObject, Vector3 startPosition, Vector3 targetPosition) {
            Vector3 currentPosition = Vector3.LerpUnclamped(startPosition, targetPosition, progress);
            gameObject.transform.position = currentPosition;
        }
        
        public static TweenInfo Move(RectTransform rectTransform, Vector2 targetPosition, float duration) {
            if(rectTransform == null) return null ;
            TweenInfo info = new TweenInfo();

            Vector2 startPosition = rectTransform.anchoredPosition;
            
            Coroutine routine = _instance.StartCoroutine(
                GenericTweenRoutineCoroutine(info, duration, null ,
                    progress => ApplyMove(progress, rectTransform, startPosition, targetPosition),
                    progress => ApplyMove(progress, rectTransform, startPosition, targetPosition),
                    customVecValue: f => Vector3.Lerp(startPosition, targetPosition, f)));

            _instance.AddNewTween(info, routine);
            return info;
        }

        private static void ApplyMove(float progress, RectTransform rectTransform, Vector2 startPosition, Vector2 targetPosition) {
            Vector2 currentPosition = Vector2.LerpUnclamped(startPosition, targetPosition, progress);
            rectTransform.anchoredPosition = currentPosition;
        }
    }
}