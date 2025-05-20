using UnityEngine;

namespace ScrollShooter {
    public class PlayerWeapon : Weapon {
        private InputReader inputReader;

        private void Awake() => inputReader = GetComponent<InputReader>();

        private void Update() {
            fireTimer += Time.deltaTime;
            if (inputReader.Fire && fireTimer > weaponStrategy.FireRate) {
                weaponStrategy.Fire(firePoint, layerMask);
                fireTimer = 0;
            }
        }
    }
}