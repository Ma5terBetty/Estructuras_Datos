using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputHandler _input;
    private ClickAction _clickAction;

    /// <summary>
    /// This just to test the npc,
    /// Need to find a way to not use dependencies
    /// </summary>
    [SerializeField] private Worker _worker;

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
        _clickAction.ClickDetect(_input.MousePosition, _worker);
    }
}
