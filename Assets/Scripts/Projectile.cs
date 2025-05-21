using System;
using UnityEngine;

namespace ScrollShooter {
    public class Projectile : MonoBehaviour {
        [SerializeField] private float speed = 10f;
        [SerializeField] private Transform muzzlePrefab;
        [SerializeField] private Transform hitPrefab;
        private Transform parent;
        public Action Callback;
        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;
        private void Start() {
            transform.SetParent(null);
            if (muzzlePrefab != null) {
                Transform muzzleVfx = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVfx.forward = gameObject.transform.forward;
                muzzleVfx.SetParent(parent);
                
                DestroyParticleSystem(muzzleVfx.gameObject);
            }
        }

        private void Update() {
            transform.position += transform.forward * (speed * Time.deltaTime);
            
            Callback?.Invoke();
        }
        private void OnCollisionEnter(Collision other) {
            if (hitPrefab != null) {
                ContactPoint contact = other.contacts[0];
                Transform hitVfx = Instantiate(hitPrefab, contact.point, Quaternion.identity);
                
                DestroyParticleSystem(hitVfx.gameObject);
            }
            Plane plane = other.gameObject.GetComponent<Plane>();
            if (plane != null) {
                plane.TakeDamage(10);
            }
            
            Destroy(gameObject);
        }

        private void DestroyParticleSystem(GameObject particle) {
            ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
            if (particleSystem == null) {
                particleSystem = particle.GetComponentInChildren<ParticleSystem>();
            }
            Destroy(particle, particleSystem.main.duration);
        }
    }
} 