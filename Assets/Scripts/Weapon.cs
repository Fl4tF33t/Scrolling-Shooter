using UnityEngine;
using Utilities;

namespace ScrollShooter {
    public abstract class Weapon : MonoBehaviour {
        [SerializeField] protected WeaponStrategy weaponStrategy;
        [SerializeField] protected Transform firePoint;
        [SerializeField, Layer] protected int layerMask;
        protected float fireTimer;
        private void OnValidate() => layerMask = gameObject.layer;

        private void Start() => weaponStrategy.Initialize();
        public void SetWeaponStrategy(WeaponStrategy strategy) {
            weaponStrategy = strategy;
            weaponStrategy.Initialize();
        }
    }
}