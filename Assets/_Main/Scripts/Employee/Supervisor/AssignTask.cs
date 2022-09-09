using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignTask : MonoBehaviour
{
    [SerializeField] private LayerMask target;


    public void SetTask(in Vector2 mousePos)
    {
        var ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, 100f, target)) return;
        if (!EmployeeManager.Instance.HasEmployee()) return;
        EmployeeManager.Instance.SetTask(hit.point, hit.collider.gameObject);
    }
}
