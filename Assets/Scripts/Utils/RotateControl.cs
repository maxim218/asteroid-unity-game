using UnityEngine;

namespace Utils {
    public class RotateControl : MonoBehaviour {
        private float _speedRotating = 0;
        private float _deltaAngle = 0;

        protected void SetDeltaAngle(float value) {
            _deltaAngle = value;
        }

        protected void SetSpeedRotating(float value) {
            _speedRotating = value;
        }
        
        protected void RotateObject(float direction) {
            transform.Rotate(0, 0, direction * _speedRotating * Time.deltaTime);
        }
        
        public float GetAngle() {
            return _deltaAngle + transform.eulerAngles.z;
        }

        public float GetRadiansAngle() {
            return GetAngle() * Mathf.PI / 180f;
        }
    }
}
