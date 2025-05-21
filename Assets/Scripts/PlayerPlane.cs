using System;
using UnityEngine;

namespace ScrollShooter {
    public class PlayerPlane : Plane {
        [SerializeField] private float maxFuel;
        [SerializeField] private float fuelConsumptionRate;
        private float fuel;
        public float GetFuelNormalized() => fuel / maxFuel;
        
        private void Start() => fuel = maxFuel;
        private void Update() {
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }
        public void AddFuel(float fuel) {
            this.fuel += fuel;
            if (this.fuel > maxFuel) {
                this.fuel = maxFuel;
            }       
        }

        protected override void Die() {
        }
    }
}