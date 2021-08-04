using System;
using UnityEngine;

namespace Utils {
    public class FollowTargetControl : MonoBehaviour {
        [SerializeField] private string targetNameString = "";
        [SerializeField] private float speed = 0;

        private GameObject _targetObjectLink = null;

        private void Start() {
            _targetObjectLink = GameObject.Find(targetNameString);
        }
        
        private void LateUpdate() {
            float x = _targetObjectLink.transform.position.x;
            float y = _targetObjectLink.transform.position.y;
            float z = transform.position.z;
            Vector3 goalPosition = new Vector3(x, y, z);
            transform.position = Vector3.MoveTowards(transform.position, goalPosition, speed * Time.deltaTime);
        }
    }
}
