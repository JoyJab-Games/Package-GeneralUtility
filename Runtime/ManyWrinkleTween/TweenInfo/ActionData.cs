using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public struct ActionData {
        public bool Canceled;
        public float? Value;
        public Vector3? Data;

        public static ActionData Null => new();
        public static ActionData Cancelled(float progress) => new() {Canceled = true, Value = progress};
        public static ActionData Progress(float progress) => new() {Value = progress};
        public static ActionData Complex(float progress, Vector3 data) => new() {Value = progress, Data = data};
    }
}