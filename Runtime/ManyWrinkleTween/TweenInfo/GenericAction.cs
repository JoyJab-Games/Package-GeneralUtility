using System;
using JescoDev.Utility.EventUtility;
using UnityEngine;

namespace JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween {
    public readonly struct GenericAction {
        
        private readonly Action _baseAction;
        private readonly Action<float> _floatAction;
        private readonly Action<Vector3> _vector3Action;

        public void Invoke() {
            _baseAction?.Invoke();
            _floatAction?.Invoke(0);
            _vector3Action?.Invoke(Vector3.zero);
        }

        public void Invoke(ActionData value) {
            _baseAction?.Invoke();
            if(value.Value.HasValue) _floatAction?.Invoke(value.Value.Value);
            if(value.Data.HasValue) _vector3Action?.Invoke(value.Data.Value);
        }
        
        public void Invoke(float floatValue, Vector3 vecValue) {
            _baseAction?.Invoke();
            _floatAction?.Invoke(floatValue);
            _vector3Action?.Invoke(vecValue);
        }
        
        public GenericAction(Action action) {
            _baseAction = action;
            _floatAction = null;
            _vector3Action = null;
        }

        public GenericAction(Action<float> action) {
            _baseAction = null;
            _floatAction = action;
            _vector3Action = null;
        }
        
        public GenericAction(Action<Vector3> action) {
            _baseAction = null;
            _floatAction = null;
            _vector3Action = action;
        }

    }
}