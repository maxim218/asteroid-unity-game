using UnityEngine;
using Utils;

namespace Flat {
    public class FlatControl : RotateControl {
        private GameObject _rocket = null;
        
        private void Start() {
            // get rocket
            _rocket = GameObject.Find("Rocket");
            
            // rotating properties
            const float speedFlatRotating = 160f;
            SetSpeedRotating(speedFlatRotating);
        }

        private void RotateToRocketDirection() {
            float flatX = gameObject.transform.position.x;
            float rocketX = _rocket.transform.position.x;
            float direction = (flatX > rocketX) ? 1f : -1f;
            RotateObject(direction);
        }
        
        private void Update() {
            RotateToRocketDirection();
        }
    }
}
