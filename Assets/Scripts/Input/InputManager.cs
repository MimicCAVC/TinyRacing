using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace TinyRacingInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInput PlayerInput;

        public float Move { get; private set; }
        public float Turn { get; private set; }

        private InputActionMap _currentMap;
        private InputAction _throttleAction;
        private InputAction _turnAction;

        private void Awake()
        {
            // finding the players keybinds
            _currentMap = PlayerInput.currentActionMap;
            _throttleAction = _currentMap.FindAction("Throttle");
            _turnAction = _currentMap.FindAction("Turn");

            // calling the functions when the player presses the keybinds
            _throttleAction.performed += onMove;
            _turnAction.performed += onLook;

            // calling the functions when the player releases the keybinds
            _throttleAction.canceled += onMove;
            _turnAction.canceled += onLook;
        }

        private void onMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<float>();
        }

        private void onLook(InputAction.CallbackContext context)
        {
            Turn = context.ReadValue<float>();
        }

        private void OnEnable()
        {
            _currentMap.Enable();
        }

        private void OnDisable()
        {
            _currentMap.Disable();
        }
    }
}

