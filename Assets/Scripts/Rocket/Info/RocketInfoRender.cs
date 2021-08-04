using System.Collections;
using RenderGui;
using Rocket.Fire;
using Rocket.Moving;
using Rocket.Rotation;
using UnityEngine;

namespace Rocket.Info {
    public class RocketInfoRender : MonoBehaviour {
        [SerializeField] private bool circleFlag = true;
        
        private GuiControl _guiControl = null;
        private RocketMovingControl _rocketMovingControl = null;
        private RocketRotationControl _rocketRotationControl = null;
        private RocketFireControl _rocketFireControl = null;
        
        private void Start() {
            _guiControl = gameObject.GetComponent<GuiControl>();
            _rocketMovingControl = gameObject.GetComponent<RocketMovingControl>();
            _rocketRotationControl = gameObject.GetComponent<RocketRotationControl>();
            _rocketFireControl = gameObject.GetComponent<RocketFireControl>();
            
            StartCoroutine( AsyncInfoChange() );
        }

        private IEnumerator AsyncInfoChange() {
            while (circleFlag) {
                yield return new WaitForSeconds(0.1f);
                MessageRenderChange();
            }
        }

        private void MessageRenderChange() {
            string infoSpeed = "Vx: " + RoundFloat(_rocketMovingControl.SpeedX) + " Vy: " + RoundFloat(_rocketMovingControl.SpeedY);
            string infoPosition = "X: " + RoundFloat(_rocketMovingControl.Position.x) + " Y: " + RoundFloat(_rocketMovingControl.Position.y);
            string infoAngle = "Angle: " + RoundFloat(_rocketRotationControl.GetAngle() % 360);
            string infoLaser = "Laser: " + _rocketFireControl.LaserNumberCount;

            string message = infoSpeed + " " + infoPosition + " " + infoAngle + " " + infoLaser;
            _guiControl.ContentSet(message);
        }

        private static float RoundFloat(float value) {
            return Mathf.Round(value * 1000) / 1000;
        }
    }
}
