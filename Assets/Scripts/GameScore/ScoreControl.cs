using UnityEngine;

namespace GameScore {
    public static class ScoreControl {
        private static int _scoreStatic = 0;

        public static int GetScoreStatic() {
            return _scoreStatic;
        }

        public static void IncreaseScoreStatic(int delta) {
            _scoreStatic += delta;
        }

        public static void ZeroScoreStatic() {
            _scoreStatic = 0;
        }
    }
}
