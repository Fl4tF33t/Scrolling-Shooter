using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace ScrollShooter {
    public class MainMenuUI : MonoBehaviour {
        [SerializeField] private Loader.Scene startingScene;
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        private void Awake() {
            playButton.onClick.AddListener(() => Loader.Load(startingScene));
            quitButton.onClick.AddListener(() => Helpers.QuitGame());
            Time.timeScale = 1f;
        }
    }
}