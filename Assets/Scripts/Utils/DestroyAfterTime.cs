using System.Collections;
using UnityEngine;

namespace Utils {
    public class DestroyAfterTime : MonoBehaviour {
        [SerializeField] private float waitTime = 0;

        private IEnumerator AsyncDestroyObject() {
            yield return new WaitForSeconds(waitTime);
            Destroy(gameObject);
        }

        private void Start() {
            StartCoroutine( AsyncDestroyObject() );
        }
    }
}
