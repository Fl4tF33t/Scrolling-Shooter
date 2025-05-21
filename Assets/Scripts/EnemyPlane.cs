namespace ScrollShooter {
    public class EnemyPlane : Plane {
        protected override void Die() {
            GameManger.Instance.AddScore(10);
            Destroy(gameObject); 
        }
    }
}