using System;
using System.Collections;
using Enemy;
using GameScore;
using UnityEngine;
using Utils;

namespace Rocket.Fire {
    public class RocketFireControl : MonoBehaviour {
        [SerializeField] private GameObject bulletPrefab = null;
        
        private bool _canFireBullet = true;
        
        public void FireBullet() {
            if (!_canFireBullet) return;
            _canFireBullet = false;
            CreateNewBullet();
            StartCoroutine( WaitAndAllowFire() );
        }

        private IEnumerator WaitAndAllowFire() {
            const float waitValue = 0.05f;
            yield return new WaitForSeconds(waitValue);
            _canFireBullet = true;
        }

        private void CreateNewBullet() {
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            const float lengthOfVector = 2f;
            bullet.transform.position = transform.TransformPoint(Vector3.up * lengthOfVector);
        }

        [SerializeField] private bool laserBool = false;
        [SerializeField] private int laserCount = 0;
        
        public int LaserNumberCount => laserCount;

        public void LaserFire() {
            if (laserBool) return;
            if (laserCount <= 0) return;
            laserCount--;
            laserBool = true;
            StartCoroutine( AsyncWaitLaser() );
        }

        private IEnumerator AsyncWaitLaser() {
            const float waitLaserValue = 1.2f;
            yield return new WaitForSeconds(waitLaserValue);
            laserBool = false;
        }

        private LineRenderer _lineRenderer = null;
        
        private void Start() {
            _lineRenderer = gameObject.GetComponent<LineRenderer>();
            SetLineLaserProps(colorOfLaser, widthOfLaser);
            SetLineLaserPosition();
            StartCoroutine( LaserAddingCount() );
        }

        [SerializeField] private bool laserAddingCountFlag = true;
        
        private IEnumerator LaserAddingCount() {
            while (laserAddingCountFlag) {
                const float seconds = 5;
                yield return new WaitForSeconds(seconds);
                laserCount++;
            }
        }

        [SerializeField] private Color colorOfLaser = Color.yellow;
        [SerializeField] private float widthOfLaser = 0.1f;
        
        private void SetLineLaserProps(Color color, float width) {
            _lineRenderer.positionCount = 2;
            // color
            _lineRenderer.startColor = color;
            _lineRenderer.endColor = color;
            // width
            _lineRenderer.startWidth = width;
            _lineRenderer.endWidth = width;
        }

        private static Vector3 NoLaserPosition() {
            const float value = -9999f;
            Vector3 position = new Vector3(value, value, value);
            return position;
        }
        
        private Vector3 GetLaserBeginPos() {
            if (laserBool) return transform.TransformPoint(Vector3.up * 2);
            return NoLaserPosition();
        }

        private Vector3 GetLaserEndPos() {
            if (laserBool) return transform.TransformPoint(Vector3.up * 1000);
            return NoLaserPosition();
        }
        
        private void SetLineLaserPosition() {
            Vector3 posA = GetLaserBeginPos();
            Vector3 posB = GetLaserEndPos();
            _lineRenderer.SetPosition(0, posA);
            _lineRenderer.SetPosition(1, posB);
        }

        private bool IsLaserHit(GameObject enemy) {
            Vector2 pA = (Vector2) GetLaserBeginPos();
            Vector2 pB = (Vector2) GetLaserEndPos();
            Vector2 pC = (Vector2) enemy.transform.position;

            Vector2 targetPoint = pC;
            if (Mathematics.IsPointMiddle(pA, targetPoint, pB) == false) return false;
            
            float distance = Mathematics.CalcHeight(pA, pB, pC);
            return (distance < 0.4f);
        }

        [SerializeField] private GameObject explosionPrefab = null;
        
        private void LaserKillEnemies() {
            if (!(FindObjectsOfType(typeof(EnemyControl)) is EnemyControl[] arr)) return;
            if (arr.Length == 0) return;
            foreach (EnemyControl enemyControlScript in arr) {
                if (!enemyControlScript) continue;
                GameObject enemy = enemyControlScript.gameObject;
                if (!IsLaserHit(enemy)) continue;
                GameObject explosion = Instantiate(explosionPrefab) as GameObject;
                explosion.transform.position = enemy.transform.position;
                explosion.transform.localScale = enemy.transform.localScale;
                EnemyControl.AppendScore();
                Destroy(enemy);
            }
        }

        private void Awake() {
            // score
            ScoreControl.ZeroScoreStatic();
            ScoreRender.RenderScore();
        }
        
        private void LateUpdate() {
            SetLineLaserPosition();
            LaserKillEnemies();
        }
    }
}
