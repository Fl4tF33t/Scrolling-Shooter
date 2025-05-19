using UnityEngine;
using UnityEngine.Splines;

namespace ScrollShooter {
    public class EnemyFactory {
        private EnemyBuilder enemyBuilder = new EnemyBuilder();

        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer splineContainer) {
            return enemyBuilder
                .SetBasePrefab(enemyType.enemyPrefab)
                .SetSpeed(enemyType.speed)
                .SetSpline(splineContainer)
                .Build();
        }    
    }
}