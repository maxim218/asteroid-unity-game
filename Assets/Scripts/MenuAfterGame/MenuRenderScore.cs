using UnityEngine;

namespace MenuAfterGame {
    public class MenuRenderScore : MonoBehaviour {
        [SerializeField] private GameObject labelObj = null;
        
        private void Start() {
            const int defaultValue = 0;
            int score = PlayerPrefs.GetInt(KeyName, defaultValue);
            labelObj.GetComponent<UnityEngine.UI.Text>().text = "Score - " + score;
        }
        
        private const string KeyName = "KeyScore";
    }
}
