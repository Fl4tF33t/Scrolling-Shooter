using System.Collections.Generic;
using MEC;
using UnityEngine.SceneManagement;

namespace ScrollShooter {
    public static class Loader {
        public enum Scene {
            MainMenu,
            Loading,
            Level1
        }

        public static void Load(Scene scene) {
            SceneManager.LoadScene(nameof(Scene.Loading));
            Timing.RunCoroutine(LoadTargetScene(scene));
        }

        private static IEnumerator<float> LoadTargetScene(Scene scene) {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(scene.ToString());
        }
    }
}