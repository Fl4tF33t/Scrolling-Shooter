using UnityEngine;

namespace ScrollShooter {
    [CreateAssetMenu(menuName = "ScriptableObjects/WeaponStrategy/TripleShot", fileName = "TripleShotStrategy", order = 0)]
    public class TripleShotStrategy : WeaponStrategy {
        [SerializeField] private float spreadAngle = 15f;
        public override void Fire(Transform firePoint, LayerMask layerMask)
        {
            const int projectileCount = 3;
            for (int i = 0; i < projectileCount; i++)
            {
                var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation, firePoint);
                projectile.transform.Rotate(0, spreadAngle * (i - 1), 0);
                projectile.layer = layerMask;
            
                var projectileComponent = projectile.GetComponent<Projectile>();
                projectileComponent.SetSpeed(projectileSpeed);
            
                Destroy(projectile, projectileLifeTime);
            }
        }

    } 
}