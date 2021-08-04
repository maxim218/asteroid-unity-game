using UnityEngine;

namespace Utils {
    public static class Mathematics {
        private static float CalcSquare(float a, float b, float c) {
            float p = 0.5f * (a + b + c);
            float s = p * (p - a) * (p - b) * (p - c);
            return Mathf.Sqrt(s);
        }

        private static float CalcLength(Vector2 pointFirst, Vector2 pointSecond) {
            float distance = Vector2.Distance(pointFirst, pointSecond);
            return distance;
        }

        public static float CalcHeight(Vector2 pA, Vector2 pB, Vector2 pC) {
            // segments length
            float segAB = CalcLength(pA, pB);
            float segAC = CalcLength(pA, pC);
            float segBC = CalcLength(pB, pC);

            // square
            float square = CalcSquare(segAB, segAC, segBC);

            // height
            float height = 2 * square / segAB;
            return height;
        }

        private static bool IsMiddle(float a, float value, float b) {
            if (a < value && value < b) return true;
            if (b < value && value < a) return true;
            return false;
        }

        public static bool IsPointMiddle(Vector2 pA, Vector2 targetPoint, Vector2 pB) {
            bool xBool = IsMiddle(pA.x, targetPoint.x, pB.x);
            bool yBool = IsMiddle(pA.y, targetPoint.y, pB.y);
            return (xBool && yBool);
        }
    }
}
