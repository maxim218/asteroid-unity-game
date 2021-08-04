using System;
using System.Linq;
using Enemy;
using GameScore;
using UnityEngine;
using Utils;

namespace Rocket.Hit {
    public class RocketHitEnemy : SceneLoad {
        [SerializeField] private float _hitDistance = 0;

        private bool OneEnemyHit(GameObject enemy) {
            Vector3 posEnemy = enemy.transform.position;
            Vector3 posRocket = transform.position;

            float distance = Vector2.Distance((Vector2) posEnemy, (Vector2) posRocket);
            bool hitBool = (distance < _hitDistance);
            return hitBool;
        }

        private bool HitControlWithAllEnemies() {
            if (!(FindObjectsOfType(typeof(EnemyControl)) is EnemyControl[] arr)) return false;
            if (arr.Length == 0) return false;
            return arr.Select(enemyControlScript => enemyControlScript.gameObject).Any(OneEnemyHit);
        }

        private bool _wasHit = false;
        
        private void LateUpdate() {
            if (_wasHit) return;
            if (!HitControlWithAllEnemies()) return;
            _wasHit = true;
            // save score
            PlayerPrefs.SetInt(KeyName, ScoreControl.GetScoreStatic());
            // scene load
            RunSceneLoading();
        }

        private const string KeyName = "KeyScore";
    }
}
