using UnityEngine;

namespace RenderGui {
    public class GuiControl : MonoBehaviour {
        [SerializeField] private GUISkin guiSkin = null;
        [SerializeField] private string content = "";
        [SerializeField] private float width = 0;
        [SerializeField] private float height = 0;
        [SerializeField] private float verticalDelta = 0;
        
        public void ContentSet(string value) {
            content = value;
        }

        private void OnGUI() {
            GUI.skin = guiSkin;
            float x = (UnityEngine.Screen.width - width) / 2;
            float y = UnityEngine.Screen.height - height - verticalDelta;
            Rect rect = new Rect(x, y, width, height);
            GUI.Box(rect, content);
        }
    }
}
