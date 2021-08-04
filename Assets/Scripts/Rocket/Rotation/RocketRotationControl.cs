using System;
using Input;
using UnityEngine;
using Utils;

namespace Rocket.Rotation {
    public class RocketRotationControl : RotateControl {
        [SerializeField] private bool inversion = false;
        [SerializeField] private float speed = 0;
        [SerializeField] private float delta = 0;
        [SerializeField] private GameObject inputStateStore = null;
        
        private InputControl _inputControl = null;
        
        private void Start() {
            _inputControl = inputStateStore.GetComponent<InputControl>();
            SetSpeedRotating(speed);
            SetDeltaAngle(delta);
        }

        private void Update() {
            float direction = _inputControl.GetDirection();
            float resultDirection = inversion ? (-1 * direction) : direction;
            RotateObject(resultDirection);
        }
    }
}
