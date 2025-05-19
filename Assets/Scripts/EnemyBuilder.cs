using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace ScrollShooter {
    public class EnemyBuilder {
        private GameObject enemyPrefab;
        private GameObject weaponPrefab;
        private float speed;
        private SplineContainer spline;

        public EnemyBuilder SetBasePrefab(GameObject prefab) {
            enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpline(SplineContainer spline) {
            this.spline = spline;
            return this;
        }

        public EnemyBuilder SetWeaponPrefab(GameObject prefab) {
            this.weaponPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpeed(float speed) {
            this.speed = speed;
            return this;
        }

        public GameObject Build() {
            GameObject instance = Object.Instantiate(enemyPrefab);
            
            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;
            splineAnimate.Play();

            instance.transform.position = spline.EvaluatePosition(0f);
            
            return instance;
        }
    }
}