using System;
using UnityEngine;

namespace ScrollShooter {
    public class ParallaxController : MonoBehaviour {
        [SerializeField] private Transform[] layers;
        [SerializeField] private float smoothing = 10f;
        [SerializeField] private float multiplier = 15f;
        
        private Transform cameraTransform;
        private Vector3 previousCameraPosition;

        private void Start() {
            cameraTransform = Camera.main.transform;
            previousCameraPosition = cameraTransform.position;
        }
        private void Update() {
            for (int i = 0; i < layers.Length; i++) {  
                float parallax = (previousCameraPosition.y - cameraTransform.position.y) * (i * multiplier);
                float targetY = layers[i].position.y + parallax;
                Vector3 backgroundTargetPosition = new Vector3(layers[i].position.x, targetY, layers[i].position.z);
                
                layers[i].position = Vector3.Lerp(layers[i].position, backgroundTargetPosition, Time.deltaTime * smoothing);
            }
            
            previousCameraPosition = cameraTransform.position;
        }
    }
}