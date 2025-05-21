using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScrollShooter {
    public class PlayerHUD : MonoBehaviour {
        [SerializeField] private Image healthBar;
        [SerializeField] private Image fuelBar;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private void Update() {
            healthBar.fillAmount = GameManger.Instance.PlayerPlane.GetHealthNormalized();
            fuelBar.fillAmount = GameManger.Instance.PlayerPlane.GetFuelNormalized();
            scoreText.text = $"Score: {GameManger.Instance.GetScore()}";
        }
    }
}