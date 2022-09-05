using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] canvases;
    private GameObject _currentCanvas;

    private void Start()
    {
        SelectCanvas(0);
    }

    public void SelectCanvas(int index)
    {
        if(_currentCanvas != null) _currentCanvas.SetActive(false);
        _currentCanvas = canvases[index];
        _currentCanvas.SetActive(true);
    }
}
