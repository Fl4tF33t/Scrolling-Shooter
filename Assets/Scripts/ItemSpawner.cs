using UnityEngine;
using Utilities;

namespace ScrollShooter {
    public class ItemSpawner : MonoBehaviour {
        [SerializeField] private Item[] items;
        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private float spawnRadius = 3f;

        private void Start() {
            InvokeRepeating("Spawn", spawnInterval, spawnInterval);
        }

        private void Spawn() {
            Item item = Instantiate(items[Random.Range(0, items.Length)]);
            item.transform.position = (transform.position + Random.insideUnitSphere).With(z:0) * spawnRadius;
        }
    }
}