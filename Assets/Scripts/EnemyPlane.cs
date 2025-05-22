using UnityEngine.Events;

namespace ScrollShooter {
    public class EnemyPlane : Plane {
        public UnityEvent OnSystemDestroyed;
        protected override void Die() {
            GameManger.Instance.AddScore(10);
            Destroy(gameObject); 
        }

    }
}