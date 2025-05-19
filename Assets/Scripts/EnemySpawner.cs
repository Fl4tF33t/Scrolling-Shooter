using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace ScrollShooter {
    public class EnemySpawner : MonoBehaviour {
        [SerializeField] private List<EnemyType> enemyTypes;
        [SerializeField] private int maxEnemies = 10;
        [SerializeField] private float spawnInterval = 2f;
        
        private List<SplineContainer> splineContainers;
        private EnemyFactory enemyFactory = new EnemyFactory();

        private float spawnTimer;
        private int enemiesSpawned;

        private void OnValidate() {
            splineContainers = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        private void Update() {
            spawnTimer += Time.deltaTime;

            if (enemiesSpawned < maxEnemies && spawnTimer > spawnInterval) {
                SpawnEnemy();
                spawnTimer = 0;
            }
        }

        private void SpawnEnemy() {
            EnemyType enemyType = enemyTypes[Random.Range(0, enemyTypes.Count)]; 
            SplineContainer splineContainer = splineContainers[Random.Range(0, splineContainers.Count)]; 
            
            GameObject enemy = enemyFactory.CreateEnemy(enemyType, splineContainer);
            enemiesSpawned++;
        }
    }
}