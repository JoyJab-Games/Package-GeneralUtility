using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public partial class ManyWrinkleTween : MonoBehaviour {

// the smooth brain instance that handles all tweens running
        private static ManyWrinkleTween _instance => _internalInstance ??= AutoGenerateScriptInstance();
        private static ManyWrinkleTween _internalInstance;

        /// <summary> </summary>
        private List<TweenInstance> _runningTweens = new();

        private ObjectPool<TweenInfo> _infoPool = new(CreateInfo, Prep);
        private static TweenInfo CreateInfo() => new();
        private static void Prep(TweenInfo info) {
            info.Running = true;
            info._onFinish.Clear();
            info._onUpdate.Clear();
            info.SetEaseLinear();
            info.SetLoop(0);
        }

        public enum UpdateMode { EveryFrame, FixedUpdate }

        public static UpdateMode TweenUpdateMode { get; set; } = UpdateMode.EveryFrame;

        private static ManyWrinkleTween AutoGenerateScriptInstance() {
            GameObject target = new GameObject("SmoothBrainTween");
            DontDestroyOnLoad(target);
            return target.AddComponent<ManyWrinkleTween>();
        }

        private void OnEnable() => StartCoroutine(RunTweens());

        private IEnumerator RunTweens() {
            WaitForFixedUpdate fixedUpdate = new();
            while (isActiveAndEnabled) {
                for (int i = 0; i < _runningTweens.Count; i++) {
                    if (!_runningTweens[i].Timer.Running) {
                        _runningTweens[i].Function.Invoke(_runningTweens[i], _runningTweens[i].Timer.CompletedLoops % 2);
                        _runningTweens[i].Info._onFinish.Invoke();
                        continue;
                    }
                    
                    float progress = _runningTweens[i].Timer.PercentProgress;
                    float progressRemapped = _runningTweens[i].Info.Easing(progress);
                    _runningTweens[i].Function.Invoke(_runningTweens[i], progressRemapped);
                    _runningTweens[i].Info._onUpdate.Invoke(progress);
                }
                
                _runningTweens.RemoveAll(instance => {
                    if (instance.Info.Running && instance.Timer.Running) return false;
                    _infoPool.Release(instance.Info);
                    return true;
                });
                
                for (int i = 0; i < _runningTweens.Count; i++) {
                    TweenInstance FUCKTHIS = _runningTweens[i];
                    FUCKTHIS.Timer.Advance(TweenUpdateMode switch {
                        UpdateMode.EveryFrame => Time.deltaTime,
                        UpdateMode.FixedUpdate => Time.fixedDeltaTime,
                        _ => throw new ArgumentOutOfRangeException()
                    });
                    _runningTweens[i] = FUCKTHIS;
                }
                yield return TweenUpdateMode switch {
                    UpdateMode.EveryFrame => null,
                    UpdateMode.FixedUpdate => fixedUpdate,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }


        internal TweenInfo AddNewTween(float duration, Transform target, Vector4 startData, Vector4 targetData, Action<TweenInstance, float> function) {
            TweenInfo info = _infoPool.Get();
            _runningTweens.Add(new TweenInstance(info, duration, target, startData, targetData, function));
            return info;
        }

        /// <summary> Stops the provided Tween from running any further </summary>
        /// <param name="tween"> the tween you want to stop </param>
        public static void Cancel(ref TweenInfo tween) {
            if (tween == null) return;
            tween.Running = false;
            tween = null; // forcefully take the reference from you, because fuck you yeeeeeeeees i am so smart 
        }
    }
}