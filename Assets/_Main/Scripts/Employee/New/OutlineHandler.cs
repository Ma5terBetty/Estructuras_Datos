using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineHandler : MonoBehaviour
{
    private Outline _selectionOutline;
    private Outline2 _backWall;

    private void Awake()
    {
        _selectionOutline = GetComponent<Outline>();
        _backWall = GetComponent<Outline2>();
    }

    private void Start()
    {
        _selectionOutline.enabled = false;
        //Debug.Log("eee");
    }
    public void SetSelectedOutline(in bool isSelected)
    {
        if (!_selectionOutline) return;
        _selectionOutline.enabled = isSelected;
    }
}
