using System;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public struct TweenTimer {
        public bool Running { get; private set; }
        public int LoopCount;
        public bool PingPong;

        public float PercentProgress => PingPong && CompletedLoops % 2 != 0
            ? Mathf.Clamp01(1 - _passedTime / _duration)
            : Mathf.Clamp01(_passedTime / _duration);

        public int CompletedLoops { get; private set; }
        
        private float _passedTime;
        private readonly float _duration;
        
        public TweenTimer(float duration) {
            _duration = duration;
            Running = true;
            CompletedLoops = 0;
            _passedTime = 0;
            LoopCount = 1;
            PingPong = false;
        }

        public void Advance(float deltaTime) {
            _passedTime += deltaTime;
            if (_duration < _passedTime) {
                CompletedLoops++;
                Running = CompletedLoops < LoopCount;
                if(PingPong || Running) _passedTime = 0;
            }
        }
    }
}