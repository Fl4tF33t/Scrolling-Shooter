using UnityEngine;

namespace ScrollShooter {
    public class Health : Item {
        private void OnTriggerEnter(Collider other) {
            other.GetComponent<PlayerPlane>().AddHealth((int) amount);
            Destroy(gameObject);
        }
    }
}