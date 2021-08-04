using UnityEngine;

namespace Screen {
    public class BorderControl : MonoBehaviour {
        [SerializeField] private float insideBorder = 0;
        [SerializeField] private float outdoorBorder = 0;
        [SerializeField] private GameObject targetObj = null;
        
        private static float CalcChangePos(float pos, float inside, float outdoor) {
            if (pos > outdoor) return -inside;
            if (pos < -outdoor) return inside;
            return pos;
        }

        private void ChangePos(GameObject obj) {
            float x = CalcChangePos(obj.transform.position.x, insideBorder, outdoorBorder);
            float y = CalcChangePos(obj.transform.position.y, insideBorder, outdoorBorder);
            float z = obj.transform.position.z;
            obj.transform.position = new Vector3(x, y, z);
        }

        private void Update() {
            ChangePos(targetObj);
        }
    }
}
