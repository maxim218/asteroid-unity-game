using System;
using Enemy;
using UnityEngine;
using Utils;

namespace Asteroid {
    public class AsteroidControl : MoveControl {
        [SerializeField] private float xSpeed = 0;
        [SerializeField] private float ySpeed = 0;
        [SerializeField] private GameObject asteroidPrefab = null;

        private bool _canGenerate = true;

        private void ProhibitGenerate() {
            _canGenerate = false;
        }
        
        private void CreateOneAsteroid(Vector3 position, Vector3 scale, float horizontalSpeed, float verticalSpeed) {
            if (!_canGenerate) return;
            
            GameObject asteroid = Instantiate(asteroidPrefab) as GameObject;
            asteroid.transform.position = position;
            asteroid.transform.localScale = scale;
            
            AsteroidControl asteroidControl = asteroid.GetComponent<AsteroidControl>();
            asteroidControl.AsteroidSpeedSet(horizontalSpeed, verticalSpeed);
            asteroidControl.ProhibitGenerate();

            EnemyControl enemyControl = asteroid.GetComponent<EnemyControl>();
            enemyControl.SetHitDistance(0.25f);
        }

        public void CreateAsteroids() {
            if (!_canGenerate) return;
            Vector3 position = transform.position;
            Vector3 scale = new Vector3(0.2f, 0.2f, 1);
            const float moduleSpeed = 3f;
            CreateOneAsteroid(position, scale, -moduleSpeed, -moduleSpeed);
            CreateOneAsteroid(position, scale, -moduleSpeed, moduleSpeed);
            CreateOneAsteroid(position, scale, moduleSpeed, -moduleSpeed);
            CreateOneAsteroid(position, scale, moduleSpeed, moduleSpeed);
        }
        
        private void Start() {
            SetSpeedHorizontalVertical(xSpeed, ySpeed);
        }

        public void AsteroidSpeedSet(float horizontalSpeed, float verticalSpeed) {
            xSpeed = horizontalSpeed;
            ySpeed = verticalSpeed;
            SetSpeedHorizontalVertical(xSpeed, ySpeed);
        }

        [SerializeField] private float borderModule = 9.5f;
        
        private void ControlFieldExit() {
            bool flagX = (Mathf.Abs(transform.position.x) > borderModule);
            bool flagY = (Mathf.Abs(transform.position.y) > borderModule);
            if (flagX || flagY) {
                Destroy(gameObject);
            }
        }
        
        private void Update() {
            MoveObject();
            ControlFieldExit();
        }
    }
}
