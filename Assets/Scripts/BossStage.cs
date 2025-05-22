using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScrollShooter {
    public class BossStage : MonoBehaviour {
        public List<EnemyPlane> enemySystems;
        public bool isBossInvulnerable = true;

        private void Start() {
            foreach (EnemyPlane enemy in enemySystems) {
                enemy.gameObject.SetActive(false);
            }
        }

        public void InitializeStage() {
            foreach (EnemyPlane enemy in enemySystems) {
                enemy.gameObject.SetActive(true);
            }
        }
        public bool IsStageComplete() {
            foreach (EnemyPlane enemy in enemySystems) {
                if (enemy != null && !(enemy.GetHealthNormalized() > 0)) {
                    return false;
                }
            }
            return true;
        }
    }
}