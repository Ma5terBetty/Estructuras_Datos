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
    /// Current mouse position
    /// </summary>
    public Vector3 MousePosition => _mousePosition;
    /// <summary>
    /// Event for when the player left clicks
    /// </summary>
    public Action OnLeftClick;
    /// <summary>
    /// Event for when the player right clicks
    /// </summary>
    public Action OnRightClick;
    /// <summary>
    /// Event for when the player double clicks with the right mouse button
    /// </summary>
    public Action OnDoubleRightClick;

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerController();
            _inputActions.Player.Pointer.performed += i => _mousePosition = i.ReadValue<Vector2>();
            _inputActions.Player.RightClick.performed += i => OnRightClick?.Invoke();
            _inputActions.Player.LeftClick.performed += i => OnLeftClick?.Invoke();
            _inputActions.Player.DobleRightClick.performed += i => OnDoubleRightClick?.Invoke();
        }

        _inputActions.Enable();
    }

    private void OnDisable() => _inputActions.Disable();

}
