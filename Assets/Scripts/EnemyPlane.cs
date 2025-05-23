using UnityEngine;
using UnityEngine.Events;

namespace ScrollShooter {
    public class EnemyPlane : Plane {
        public UnityEvent OnSystemDestroyed;
        [SerializeField] private Transform destroyVfx;
        protected override void Die() {
            GameManger.Instance.AddScore(10);
            OnSystemDestroyed?.Invoke();
            Instantiate(destroyVfx, transform.position, transform.rotation);
            Destroy(gameObject); 
        }

    }
}