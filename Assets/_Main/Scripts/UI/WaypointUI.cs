using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointUI : MonoBehaviour
{
    private Waypoint _waypoint;
    private BoxCollider _collider;
    private Canvas _canvas;
    [SerializeField] private bool showUI;

    private void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
        _collider = GetComponent<BoxCollider>();
        _canvas = GetComponentInChildren<Canvas>();
    }

    private void Start()
    {
        if (!showUI)
        {
            _canvas.gameObject.SetActive(false);
            return;
        }

        var size = _collider.size;
        _canvas.transform.localScale = new Vector3(size.x, size.y);
    }
}
