using UnityEngine;

namespace GameScore {
    public static class ScoreRender {
        private static UnityEngine.UI.Text script = null;
        
        private static UnityEngine.UI.Text UiComponentGet(string nameString) {
            GameObject obj = GameObject.Find(nameString); 
            return obj.GetComponent<UnityEngine.UI.Text>();
        }
        
        public static void RenderScore() {
            const string nameString = "ScoreText";
            if (!script) script = UiComponentGet(nameString);
            script.text = "Score: " + ScoreControl.GetScoreStatic();
        }
    }
}
