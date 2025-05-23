using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScrollShooter
{
    public class Boss : MonoBehaviour {
        [SerializeField] private Transform destroyVfx;
        [SerializeField] private float maxHealth = 100f;
        private float health;

        private Collider bossCollider;

        public List<BossStage> stages;
        private int currentStage = 0;

        private void Awake() {
            bossCollider = GetComponent<Collider>();
        }

        private void Start() {
            health = maxHealth;
            bossCollider.enabled = true;
            
            InitializeStage();
        }
        
        public float GetHealthNormalized() => health / maxHealth;

        private void AdvanceToNextStage() {
            currentStage++;
            bossCollider.enabled = true;

            if (currentStage < stages.Count) {
                InitializeStage();
            }
        }
        private void CheckStageComplete() {
            if (stages[currentStage].IsStageComplete()) {
                AdvanceToNextStage();
            }
        }
        private void InitializeStage() {
            stages[currentStage].InitializeStage();
            bossCollider.enabled = !stages[currentStage].isBossInvulnerable;
            foreach (BossStage stage in stages) {
                foreach (EnemyPlane enemyPlane in stage.enemySystems) {
                    enemyPlane.OnSystemDestroyed.AddListener(CheckStageComplete);
                }
            }
        }

        private void OnCollisionEnter(Collision other) {
            health -= 10;
            if (health <= 0) {
                BossDefeated();
            }
        }

        private void BossDefeated() {
            Instantiate(destroyVfx, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
