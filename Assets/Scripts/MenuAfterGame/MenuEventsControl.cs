using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace MenuAfterGame {
    public class MenuEventsControl : SceneLoad {
        private void Start() {
            const string nameString = "SampleScene";
            NameSceneSet(nameString);
        }
        
        private void RestartOperation() {
            const string msg = "Restart";
            Debug.Log(msg);
            RunSceneLoading();
        }
        
        private static void QuitOperation() {
            const string msg = "Quit";
            Debug.Log(msg);
            Application.Quit();
        }
        
        public void ButtonsPushing(InputAction.CallbackContext context) {
            float value = context.ReadValue<float>();
            if (value > 0) QuitOperation();
            if (value < 0) RestartOperation();
        }
    }
}
