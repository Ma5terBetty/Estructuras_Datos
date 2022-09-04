using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It is the sript that tells the employees what to do
/// It utilize the Facade design pattern
/// </summary>
public class Supervisor : MonoBehaviour
{
    private InputHandler _input;
    private ClickAction _clickAction;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
        _clickAction = GetComponent<ClickAction>();
    }

    private void Start()
    {
        _input.OnClick += Click;
    }

    private void OnDisable()
    {
        _input.OnClick -= Click;
    }

    private void Click()
    {
        _clickAction.ClickDetect(_input.MousePosition);
    }
}
