using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils {
    public class SceneLoad : MonoBehaviour {
        private string stringSceneName = "ScoreWatchScene";

        protected void NameSceneSet(string nameString) {
            stringSceneName = nameString;
        }

        private IEnumerator LoadSceneAsync() {
            AsyncOperation operation = SceneManager.LoadSceneAsync(stringSceneName);
            while(!operation.isDone) yield return new WaitForSeconds(1);
        }

        private bool _flag = true;
        
        protected void RunSceneLoading() {
            if (!_flag) return;
            _flag = false;
            StartCoroutine( LoadSceneAsync() );
        }
    }
}
