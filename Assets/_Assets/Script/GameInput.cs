using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInput _playerInput;
    public event EventHandler OnInteractionPressed;


    private void Awake()
    {
        _playerInput = new();

        _playerInput.Enable();

        _playerInput.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractionPressed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetNormailizedInput()
    {
        return _playerInput.Player.Move.ReadValue<Vector2>();
    }


}
