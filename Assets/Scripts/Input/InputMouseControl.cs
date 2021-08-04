using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Input {
    public class InputMouseControl : MonoBehaviour {
        [SerializeField] private UnityEvent eventLeft = null;
        [SerializeField] private UnityEvent eventRight = null;

        public void MouseLeft(InputAction.CallbackContext context) {
            float value = context.ReadValue<float>();
            if(value > 0) eventLeft.Invoke();
        }
        
        public void MouseRight(InputAction.CallbackContext context) {
            float value = context.ReadValue<float>();
            if(value > 0) eventRight.Invoke();
        }
    }
}
