using UnityEngine;
using UnityEngine.InputSystem;

namespace Input {
   public class InputControl : MonoBehaviour {
      private float _direction = 0;

      public float GetDirection() {
         return _direction;
      }
      
      public void InputOfUser(InputAction.CallbackContext context) {
         _direction = context.ReadValue<float>();
      }
   }
}
