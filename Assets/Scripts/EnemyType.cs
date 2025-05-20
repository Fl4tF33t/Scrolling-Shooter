using UnityEngine;

namespace ScrollShooter {
    [CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
    public class EnemyType : ScriptableObject {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;
    }
}