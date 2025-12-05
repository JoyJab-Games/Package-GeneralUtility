using JescoDev.Utility.EventUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween : MonoBehaviour {

// the smooth brain instance that handles all tweens running
        private static ManyWrinkleTween _instance => _internalInstance ??= AutoGenerateScriptInstance();
        private static ManyWrinkleTween _internalInstance;

        /// <summary> </summary>
        private TweenInstance[] _tweens = Array.Empty<TweenInstance>();
        private readonly Stack<int> _freeTweens = new();

        public enum UpdateMode { EveryFrame, FixedUpdate }

        public static UpdateMode TweenUpdateMode { get; set; } = UpdateMode.EveryFrame;

        private static ManyWrinkleTween AutoGenerateScriptInstance() {
            GameObject target = new GameObject("SmoothBrainTween");
            DontDestroyOnLoad(target);
            return target.AddComponent<ManyWrinkleTween>();
        }

        private void OnEnable() {
            _tweens = new TweenInstance[100];
            _freeTweens.Clear();
            for (int i = 0; i < _tweens.Length; i++) {
                _freeTweens.Push(i);
                _tweens[i].Generation = 1;
            }
            StartCoroutine(RunTweens());
        }

        private IEnumerator RunTweens() {
            WaitForFixedUpdate fixedUpdate = new();
            while (isActiveAndEnabled) {
                for (int i = 0; i < _tweens.Length; i++) {
                    if (!_tweens[i].Running) continue;
                    
                    float progress = _tweens[i].Timer.PercentProgress;
                    float progressRemapped = _tweens[i].Easing(progress);
                    if (!_tweens[i].Timer.Running) {
                        try {
                            ActionData data = _tweens[i].Function.Invoke(_tweens[i], progressRemapped);
                            _tweens[i]._onFinish.Invoke(data);
                        }
                        catch { /* ignored */ }
                        Cancel(i);
                        continue;
                    }
                    try {
                        ActionData actionData = _tweens[i].Function.Invoke(_tweens[i], progressRemapped);
                        if(!actionData.Canceled) _tweens[i]._onUpdate.Invoke(actionData);
                        else Cancel(i);
                    }
                    catch (Exception e) {
                       Debug.LogException(e);
                       Cancel(i);
                    }
                }
                
                for (int i = 0; i < _tweens.Length; i++) {
                    TweenInstance brothaaaaa = _tweens[i];
                    brothaaaaa.Timer.Advance(TweenUpdateMode switch {
                        UpdateMode.EveryFrame => Time.deltaTime,
                        UpdateMode.FixedUpdate => Time.fixedDeltaTime,
                        _ => throw new ArgumentOutOfRangeException()
                    });
                    _tweens[i] = brothaaaaa;
                }
                yield return TweenUpdateMode switch {
                    UpdateMode.EveryFrame => null,
                    UpdateMode.FixedUpdate => fixedUpdate,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        internal TweenHandle AddNewTween(float duration, Vector4 startData, Vector4 targetData, Func<TweenInstance, float, ActionData> function) {
            int index = GetFreeTweenIndex(); 
            int generation = _tweens[index].Generation; 
            _tweens[index] = new TweenInstance(generation, duration, startData, targetData, function);
            return new TweenHandle(index, generation);
        }
        
        internal TweenHandle AddNewTween(float duration, Transform target, Vector4 startData, Vector4 targetData, Func<TweenInstance, float, ActionData> function) {
            int index = GetFreeTweenIndex(); 
            int generation = _tweens[index].Generation;
            _tweens[index] = new TweenInstance(generation, duration, target, startData, targetData, function);
            return new TweenHandle(index, generation);
        }

        internal TweenHandle AddNewTween(float duration, Object target, Vector4 startData, Vector4 targetData, Func<TweenInstance, float, ActionData> function) {
            int index = GetFreeTweenIndex(); 
            int generation = _tweens[index].Generation;
            _tweens[index] = new TweenInstance(generation, duration, target, startData, targetData, function);
            return new TweenHandle(index, generation);
        }

        private int GetFreeTweenIndex() {
            if (_freeTweens.Count > 0) return _freeTweens.Pop();

            int oldSize = _tweens.Length;
            Array.Resize(ref _tweens, oldSize * 2);
            for (int i = oldSize; i < _tweens.Length; i++) {
                _freeTweens.Push(i);
                _tweens[i].Generation = 1;
            }
            return _freeTweens.Pop();
        }

        internal static bool IsValidHandle(TweenHandle handle) {
            if (handle.Index < 0 || handle.Index >= _instance._tweens.Length) return false;
            if (handle.Generation == 0) return false;
            return handle.Generation == _instance._tweens[handle.Index].Generation;
        }
        internal static ref TweenInstance TryGetTween(TweenHandle handle) {
            if (IsValidHandle(handle)) return ref _instance._tweens[handle.Index];
            throw new Exception("TweenHandle is invalid");
        }

        public static void ForceFinish(TweenHandle tween) {
            if(!IsValidHandle(tween)) return;
            ref TweenInstance instance = ref _instance._tweens[tween.Index];
            _instance.Cancel(tween.Index, ref instance);
            try {
                float progressRemapped = instance.Easing(1f);
                ActionData data = instance.Function.Invoke(instance, progressRemapped);
                instance._onUpdate.Invoke(data);
                instance._onFinish.Invoke(data);
            }
            catch { /* ignored */ }
        }

        /// <summary> Stops the provided Tween from running any further </summary>
        /// <param name="tween"> the tween you want to stop </param>
        public static void Cancel(TweenHandle tween) {
            if (!IsValidHandle(tween)) return;
            _instance.Cancel(tween.Index);
        }
        private void Cancel(int index) {
            ref TweenInstance instance = ref _tweens[index];
            Cancel(index, ref instance);
        }

        private void Cancel(int index, ref TweenInstance instance) {
            instance.Running = false;
            instance.Generation++; // break old handle
            if(instance.Generation == 0) instance.Generation++; // avoid 0 on overflow
            _freeTweens.Push(index);
        }
    }
}