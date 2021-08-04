using UnityEngine;

namespace Utils {
    public class MoveControl : MonoBehaviour {
        private float _speedHorizontal = 0;
        private float _speedVertical = 0;

        protected void SetSpeedHorizontalVertical(float horizontal, float vertical) {
            _speedHorizontal = horizontal;
            _speedVertical = vertical;
        }

        protected void MoveObject() {
            transform.Translate(_speedHorizontal * Time.deltaTime, _speedVertical * Time.deltaTime, 0, Space.World);
        }
    }
}
