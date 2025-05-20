using UnityEngine;

namespace ScrollShooter {
    [CreateAssetMenu(menuName = "ScriptableObjects/WeaponStrategy/SingleShot", fileName = "SingleShotStrategy", order = 0)]

    public class SingleShotStrategy : WeaponStrategy {
        public override void Fire(Transform firePoint, LayerMask layerMask) {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation, firePoint);
            projectile.layer = layerMask;
            
            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);
            
            Destroy(projectile, projectileLifeTime);
        }
    }
}