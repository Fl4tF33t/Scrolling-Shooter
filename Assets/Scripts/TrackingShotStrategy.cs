using UnityEngine;
using Utilities;

namespace ScrollShooter {
    [CreateAssetMenu(menuName = "ScriptableObjects/WeaponStrategy/TrackingShot", fileName = "TrackingShotStrategy", order = 0)]
    public class TrackingShotStrategy : WeaponStrategy {
        [SerializeField] private float trackingSpeed = 1f;
        private Transform target;

        public override void Initialize() {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        public override void Fire(Transform firePoint, LayerMask layerMask) {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation, firePoint);
            projectile.layer = layerMask;
            
            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);

            projectileComponent.Callback = () => {
                Vector3 direction = (target.position - projectile.transform.position).With(firePoint.position.z).normalized;
                
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
                projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, rotation, trackingSpeed * Time.deltaTime);
            };
            
            Destroy(projectile, projectileLifeTime);
        }
    }
}