using UnityEngine;
using UnityEngine.InputSystem;

namespace ScrollShooter {
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour {
        private PlayerInput playerInput;
        private InputAction moveAction;
        
        public Vector2 Move => moveAction.ReadValue<Vector2>();
        private void Start() {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
        }
        
    }
}
