using Asteroid;
using UnityEngine;

namespace Source {
    public class SourceControl : MonoBehaviour {
        [SerializeField] private GameObject asteroidPrefab = null;
        [SerializeField] private GameObject flatPrefab = null;

        private int _direction = 0;
        
        private void Start() {
            _direction = (transform.position.y > 0) ? -1 : 1;
        }
        
        private void PositionSet(GameObject obj) {
            float x = transform.position.x;
            float y = transform.position.y;
            const float z = 3;
            obj.transform.position = new Vector3(x, y, z);
        }
        
        public void CreateFlat() {
            GameObject flat = Instantiate(flatPrefab) as GameObject;
            PositionSet(flat);
        }

        public void CreateAsteroid() {
            GameObject asteroid = Instantiate(asteroidPrefab) as GameObject;
            PositionSet(asteroid);
            AsteroidControl script = asteroid.GetComponent<AsteroidControl>();
            float horizontalSpeed = Random.Range(-2.5f, 2.5f);
            float verticalSpeed = Random.Range(2f, 4f) * _direction;
            script.AsteroidSpeedSet(horizontalSpeed, verticalSpeed);
        }
    }
}
