using System;
using UnityEngine;

namespace ScrollShooter {
    public class EnemyWeapon : Weapon {
        private void Update() {
            fireTimer += Time.deltaTime;
            if (fireTimer > weaponStrategy.FireRate) {
                weaponStrategy.Fire(firePoint, layerMask);
                fireTimer = 0;
            }
        }
    }
}