using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelected : MonoBehaviour
{
    [SerializeField] private Renderer targerRenderer;
    [SerializeField] private Color selectedColor;

    private void OnMouseEnter()
    {
        targerRenderer.material.color = selectedColor;
    }

    private void OnMouseExit()
    {
        targerRenderer.material.color = Color.white;
    }
}
