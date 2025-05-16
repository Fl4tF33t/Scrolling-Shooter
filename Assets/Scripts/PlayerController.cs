using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScrollShooter {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private GameObject model;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float smoothness = 0.1f;
        [SerializeField] private float leanAngle = 15f;
        [SerializeField] private float leanSpeed = 5f;

        [Header("Camera Bounds")] 
        [SerializeField] private Transform cameraFollow;
        [SerializeField] private float minX = -10f;
        [SerializeField] private float maxX = 10f;
        [SerializeField] private float minY = -10f;
        [SerializeField] private float maxY = 10f;
        
        private InputReader inputReader;

        private Vector3 currentVelocity;
        private Vector3 targetPosition;

        private void Start() {
            inputReader = GetComponent<InputReader>();
        }

        private void Update() {
            targetPosition += new Vector3(inputReader.Move.x, inputReader.Move.y, 0) * (speed * Time.deltaTime);
            
            float minPlayerX = cameraFollow.position.x + minX;
            float maxPlayerX = cameraFollow.position.x + maxX;
            float minPlayerY = cameraFollow.position.y + minY;
            float maxPlayerY = cameraFollow.position.y + maxY;
            
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);
            
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);
            
            float targetRotationAngle = -inputReader.Move.x * leanAngle;
            float currentYRotation = transform.eulerAngles.y;
            float newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);
            
            transform.localEulerAngles = new Vector3(0, newYRotation, 0);
        }
    }
}
