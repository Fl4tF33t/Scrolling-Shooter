using UnityEngine;
using UnityEngine.InputSystem;

namespace ScrollShooter {
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour {
        private PlayerInput playerInput;
        private InputAction moveAction;
        private InputAction fireAction;
        public Vector2 Move => moveAction.ReadValue<Vector2>();
        public bool Fire => fireAction.triggered;
        private void Start() {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
            fireAction = playerInput.actions["Attack"];
        }
    }
}
