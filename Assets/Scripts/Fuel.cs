using UnityEngine;

namespace ScrollShooter {
    public class Fuel : Item {
        private void OnTriggerEnter(Collider other) {
            other.GetComponent<PlayerPlane>().AddFuel(amount);
            Destroy(gameObject);
        }
    }
}