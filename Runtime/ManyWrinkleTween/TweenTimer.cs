using System;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public struct TweenTimer {
        public bool Running { get; private set; }

        public float PercentProgress => _info.PingPong && CompletedLoops % 2 != 0
            ? Mathf.Clamp01(1 - _passedTime / _duration)
            : Mathf.Clamp01(_passedTime / _duration);

        public int CompletedLoops { get; private set; }
        
        private float _passedTime;
        private readonly float _duration;
        private readonly TweenInfo _info;
        
        public TweenTimer(TweenInfo info, float duration) {
            _info = info;
            _duration = duration;
            Running = true;
            CompletedLoops = 0;
            _passedTime = 0;
        }

        public void Advance(float deltaTime) {
            _passedTime += deltaTime;
            if (_duration < _passedTime) {
                CompletedLoops++;
                Running = CompletedLoops < _info.LoopCount;
                if(_info.PingPong || Running) _passedTime = 0;
            }
        }
    }
}