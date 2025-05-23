using System;
using UnityEngine;

namespace ScrollShooter {
    public class GameManger : MonoBehaviour {
        [SerializeField] private GameObject gameOverUI;
        public static GameManger Instance { get; private set; }
        public PlayerPlane PlayerPlane => playerPlane;
        private PlayerPlane playerPlane;
        private int score;
        private float restartTimer = 3f;
        private Boss boss;
        
        private void Awake() {
            Instance = this;
            
            playerPlane = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlane>();
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        }
        private void Update() {
            if (IsGameOver()) {
                restartTimer -= Time.deltaTime;
                if (!gameOverUI.activeSelf) {
                    gameOverUI.SetActive(true);   
                }
                if (restartTimer <= 0) {
                    Loader.Load(Loader.Scene.MainMenu);
                }
            }
        }
        
        public bool IsGameOver() => playerPlane.GetHealthNormalized() <= 0 || playerPlane.GetFuelNormalized() <= 0 || boss.GetHealthNormalized() <= 0;
        public void AddScore(int score) => this.score += score;
        public int GetScore() => score;

    }
}