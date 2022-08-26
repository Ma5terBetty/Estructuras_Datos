using System;
using UnityEngine;

/// <summary>
/// This class takes care of the player inputs
/// </summary>
public class InputHandler : MonoBehaviour
{
    private PlayerController _inputActions;
    private Vector2 _mousePosition;
    /// <summary>
    /// Event for when the player left clicks with the mouse
    /// </summary>
    public Action OnClick;
    /// <summary>
    /// Current mouse position
    /// </summary>
    public Vector3 MousePosition => _mousePosition;


    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerController();
            _inputActions.Player.Pointer.performed += i => _mousePosition = i.ReadValue<Vector2>();
            _inputActions.Player.Click.performed += i => OnClick?.Invoke();
        }

        _inputActions.Enable();
    }

    private void OnDisable() => _inputActions.Disable();
}
