using Asteroid;
using Bullet;
using GameScore;
using UnityEngine;

namespace Enemy {
    public class EnemyControl : MonoBehaviour {
        [SerializeField] private float hitDistanceValue = 0;
        [SerializeField] private GameObject deadFlatPrefab = null;

        public void SetHitDistance(float value) {
            hitDistanceValue = value;
        }
        
        private void DeadObjectsCreate() {
            // create explosion
            GameObject deadObj = Instantiate(deadFlatPrefab) as GameObject; 
            deadObj.transform.position = transform.position;
            deadObj.transform.localScale = transform.localScale;
            
            // create asteroids if it was asteroid
            AsteroidControl script = gameObject.GetComponent<AsteroidControl>();
            if (script) script.CreateAsteroids();
        }
        
        private void HitBulletsControl() {
            if (!(FindObjectsOfType(typeof(BulletControl)) is BulletControl[] arr)) return;
            if (arr.Length == 0) return;
            foreach (BulletControl bulletControlScript in arr) {
                if (!bulletControlScript) continue;
                GameObject bullet = bulletControlScript.gameObject;
                if (!IsHit(hitDistanceValue, bullet)) continue;
                Destroy(bullet);
                DeadObjectsCreate();
                AppendScore();
                Destroy(gameObject);
                return;
            }
        }

        public static void AppendScore() {
            const int delta = 1;
            ScoreControl.IncreaseScoreStatic(delta);
            ScoreRender.RenderScore();
        }
        
        private bool IsHit(float hitDistance, GameObject bullet) {
            Vector3 posBullet = bullet.transform.position;
            Vector3 posEnemy = transform.position;
            float distance = Vector2.Distance((Vector2) posBullet, (Vector2) posEnemy);
            return (distance < hitDistance);
        }

        private void Update() {
            HitBulletsControl();
        }
    }
}
