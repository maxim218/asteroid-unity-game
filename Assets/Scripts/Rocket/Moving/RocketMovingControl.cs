using System;
using Input;
using Rocket.Rotation;
using UnityEngine;
using Utils;

namespace Rocket.Moving {
    public class RocketMovingControl : MoveControl {
        [SerializeField] private float acceleration = 0;
        [SerializeField] private float attenuation = 0;
        [SerializeField] private GameObject inputStateStore = null;
        
        private InputControl _inputControl = null;
        private RocketRotationControl _rotationControl = null;
        private float _stateSpeedX = 0;
        private float _stateSpeedY = 0;
        
        public float SpeedX => _stateSpeedX;
        public float SpeedY => _stateSpeedY;

        public Vector3 Position => transform.position;

        private void Start() {
            _inputControl = inputStateStore.GetComponent<InputControl>();
            _rotationControl = gameObject.GetComponent<RocketRotationControl>();
        }

        private void Update() {
            SetSpeedHorizontalVertical(_stateSpeedX, _stateSpeedY);
            MoveObject();
        }

        private void AccelerateRocket(float radiansAngle) {
            _stateSpeedX += acceleration * Mathf.Cos(radiansAngle);
            _stateSpeedY += acceleration * Mathf.Sin(radiansAngle);
        }

        private void AttenuateRocket() {
            _stateSpeedX = AttenuateByAxis(_stateSpeedX);
            _stateSpeedY = AttenuateByAxis(_stateSpeedY);
        }

        private float AttenuateByAxis(float axisSpeed) {
            bool condition = (axisSpeed > 0);
            float resultAxisSpeed = condition ? (axisSpeed - attenuation) : (axisSpeed + attenuation);
            return resultAxisSpeed;
        }
        
        private void FixedUpdate() {
            float direction = _inputControl.GetDirection();
            float radiansAngle = _rotationControl.GetRadiansAngle();
            if (direction > 0) AccelerateRocket(radiansAngle);
            AttenuateRocket();
        }
    }
}
