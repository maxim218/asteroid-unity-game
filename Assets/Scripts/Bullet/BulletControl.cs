using System;
using Rocket.Rotation;
using UnityEngine;
using Utils;

namespace Bullet {
    public class BulletControl : MoveControl {
        [SerializeField] private float speedModule = 0;

        private void Start() {
            // get angle of rocket
            GameObject rocket = GameObject.Find("Rocket");
            RocketRotationControl script = rocket.GetComponent<RocketRotationControl>();
            float radiansAngle = script.GetRadiansAngle();
            
            // calculate speed projections
            float speedX = speedModule * Mathf.Cos(radiansAngle);
            float speedY = speedModule * Mathf.Sin(radiansAngle);
            
            // set speed
            SetSpeedHorizontalVertical(speedX, speedY);
        }

        private void LateUpdate() {
            MoveObject();
        }
    }
}
