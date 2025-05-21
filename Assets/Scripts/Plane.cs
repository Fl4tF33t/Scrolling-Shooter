using System;
using UnityEngine;

namespace ScrollShooter {
    public abstract class Plane : MonoBehaviour {
        [SerializeField] private int maxHealth = 100;
        private int health;

        protected void Awake() {
            health = maxHealth;
        }
        
        public void SetMaxHealth(int maxHealth) => this.maxHealth = maxHealth;
        public void TakeDamage(int damage) {
            health -= damage;
            if (health <= 0) {
                Die();
            }
        }

        public void AddHealth(int health) {
            this.health += health;
            if (this.health > maxHealth) {
                this.health = maxHealth;
            }       
        }

        public float GetHealthNormalized() => (float)health / maxHealth;  

        protected abstract void Die();
    }
}