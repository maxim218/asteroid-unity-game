using System.Collections;
using Enemy;
using UnityEngine;
using Utils;

namespace Source {
    public class ManagerOfSources : MonoBehaviour {
        [SerializeField] private int maxEnemiesNumber = 0;
        
        private static int NumberOfEnemies() {
            if (!(FindObjectsOfType(typeof(EnemyControl)) is EnemyControl[] mass)) return 0;
            return mass.Length;
        }

        [SerializeField] private float waitValue = 0;
        [SerializeField] private bool countingCycle = true;

        private void Start() {
            StartCoroutine( AsyncTimerCounter() );
        }

        private void ActionOfTimer() {
            if (NumberOfEnemies() >= maxEnemiesNumber) return;

            SourceControl [] arr = GetSourcesArray();
            int length = arr.Length;
            int index = Random.Range(100, 200) % length;
            SourceControl sourceControl = arr[index];
            if (index % 3 == 0) {
                sourceControl.CreateFlat();
            } else {
                sourceControl.CreateAsteroid();
            }
        }
        
        private IEnumerator AsyncTimerCounter() {
            while (countingCycle) {
                yield return new WaitForSeconds(waitValue);
                ActionOfTimer();
            }
        }

        private static SourceControl [] GetSourcesArray() {
            return FindObjectsOfType(typeof(SourceControl)) as SourceControl[];
        }
    }
}
